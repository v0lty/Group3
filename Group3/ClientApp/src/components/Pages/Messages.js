import React, { useState, useContext, useEffect } from 'react';
import API from "../API";
import { AuthContext } from "../UserAuthentication";
import moment from "moment";
import Col from 'react-bootstrap/Col';
import Nav from 'react-bootstrap/Nav';
import Row from 'react-bootstrap/Row';
import Tab from 'react-bootstrap/Tab';
import InputModal from '../InputModal';
import UserSelectModal from '../UserSelectModal';
import { useParams } from 'react-router';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAdd, faReply, faTrash } from '@fortawesome/free-solid-svg-icons'
import UserGroup from '../UserGroup';

export const Messages = props => {
    const authContext = useContext(AuthContext);
    const [conversations, setConversations] = useState([]);
    const [selectedConversation, setSelectedConversation] = useState(null);
    const [selectedUsers, setSelectedUsers] = useState([]);
    const [showCreateMessageModal, setShowCreateMessageModal] = useState(false);
    const [showUsersSelectModal, setShowUsersSelectModal] = useState(false);

    const [bottomElement, setBottomElement] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        if (id != null && id != "null") {
            API.getUserById({
                userId: id
            }).then((user) => {
                setSelectedUsers([authContext?.user, user]);
                setShowCreateMessageModal(true);
            });
        }
        updateConversations();
        scrollToBottom();
    }, [id])

    const scrollToBottom = () => {        
        if (bottomElement != null) {          
            bottomElement.scrollIntoView({ behavior: 'smooth', block: 'nearest', inline: 'start' });
        }
    }

    const updateConversations = () => {
        console.log(authContext?.user);
        API.getConversations({
            userId: authContext?.user?.Id,
        }).then((conversations) => {
            setConversations(conversations);
            scrollToBottom();
        });
    };

    const onChange = (value) => {
        setValue(value);
    };

    const onReplay = (conversation) => {
        setSelectedUsers(conversation?.ConversationParticipations?.map(x => (x.User)));
        setSelectedConversation(conversation);
        setShowCreateMessageModal(true);
    };

    const onCreateConversation = () => {
        setShowUsersSelectModal(true);
    };

    const onCreateMessageSubmit = async (event, title, text) => {

        if (selectedConversation == null) {
            /*NEW CONVERSATION*/
            var userIds = selectedUsers?.map(x => (x.Id)).join(',');
            console.log(userIds);
            API.createConversation({
                authorId: authContext?.user?.Id,
                userIds: userIds,
            }).then((conversation) => {
                /*NEW MESSAGE IN NEW CONVERSATION*/
                API.createConversationMessage({
                    conversationId: conversation?.Id,
                    authorId: authContext?.user.Id,
                    text: text,
                }).then(() => {
                    updateConversations();
                });
            });
        }
        else {
            /*NEW MESSAGE IN EXISTING CONVERSATION*/
            API.createConversationMessage({
                conversationId: selectedConversation?.Id,
                authorId: authContext?.user.Id,
                text: text,
            }).then(() => {
                updateConversations();
            });
        }
        setShowCreateMessageModal(false);
        setShowUsersSelectModal(false);
        setSelectedConversation(null);
        setSelectedUsers(null);
    }

    const onUsersSelectSubmit = async (users) => {      
        if (!users.map(x => (x.Id)).includes(authContext?.user?.Id)) {
            users.push(authContext.user);
        }        
        setSelectedUsers(users);
        setShowUsersSelectModal(false);
        setShowCreateMessageModal(true);
    }

    const onDeleteClick = (message) => {
        API.deleteConversationMessage({
            messageId: message?.Id,
        }).then(() => {
            updateConversations();
        });
    }

    return (
        <div className="context bg-white shadow">
            <h4>Conversations</h4><br />
            <Tab.Container defaultActiveKey="0">                
                <Row>                 
                    {/*BUTTONS*/}
                    <Col sm={4}>                        
                        <Nav variant="pills" className="flex-column border-bottom">
                            {conversations?.map((conversation, conversationIndex) =>
                                <Nav.Item key={conversationIndex} className="mb-2">
                                    <Nav.Link eventKey={conversationIndex} onClick={() => scrollToBottom()}>
                                        {/*NAMES*/}
                                        <UserGroup users={conversation?.ConversationParticipations?.map(x => (x.User))} />
                                    </Nav.Link>
                                </Nav.Item>
                            )}
                        </Nav>
                        {/*CONVERSATION BUTTON*/}
                        <button className="btn btn-link mt-3 text-success" onClick={onCreateConversation}>
                            <FontAwesomeIcon icon={faAdd} />
                        </button>
                    </Col>
                    {/*CONTENT*/}
                    <Col sm={8} className="px-5 scrollable-100">
                    {conversations?.map((conversation, conversationIndex) =>
                        <Tab.Content key={conversationIndex}>
                            <Tab.Pane eventKey={conversationIndex}>
                                <div className="">
                                    {conversation.Messages.map((message, messageIndex) =>
                                    /*BUBBLE*/
                                    <div key={messageIndex} className={message?.Author?.Id == authContext.user?.Id
                                            ? "row bubble-right mt-4"
                                            : "row bubble mt-4"}>
                                        {/*USER*/}
                                        <div className="col-3" style={{ width: 100 }}>                                        
                                            <div className="text-center p-2">
                                                {/*USERPICTURE*/}
                                                <img className="profile-image-small" src={`../Pictures/${message?.Author.ProfilePicture?.Path}`}></img>                                           
                                                {/*USERNAME*/}
                                                {authContext?.user?.Id == message.Author.Id ? (
                                                    <h5>You</h5>) : (                                       
                                                    <h5>{message.Author.FirstName}</h5>
                                                )}                                             
                                            </div>
                                        </div>
                                        <div className="col">
                                            <div className="row">
                                                {/*TIME*/}
                                                <span>                                                
                                                    <span className="float-end">{moment(message.Time).fromNow()}</span>
                                                </span>
                                                {/*TEXT*/}
                                                <div dangerouslySetInnerHTML={{ __html: message.Text }} />                                        
                                            </div>
                                            </div>
                                            {authContext?.user?.Id == message.Author.Id && (
                                                <span>
                                                    <button className="btn btn-link text-danger float-end p-0 m-0" onClick={() => { onDeleteClick(message); }}>
                                                        <FontAwesomeIcon icon={faTrash} />
                                                    </button>
                                                </span>
                                            )}
                                    </div>
                                    )}
                                </div>
                                {/*MESSAGE BUTTON*/}
                                <div className="text-end">
                                    <button className="btn btn-link border-0 bubble-right fw-bold mt-4 px-5" style={{ minHeight: 75 }} onClick={() => onReplay(conversation)}>
                                        <FontAwesomeIcon icon={faReply} />
                                    </button>
                                </div>
                            </Tab.Pane>
                        </Tab.Content>                          
                        )}
                        <div style={{ float: "right", clear: "both" }} ref={(el) => { setBottomElement(el); }} />
                    </Col>
                </Row>
                <UserSelectModal
                    title="Select People"
                    onSubmit={onUsersSelectSubmit}
                    visible={showUsersSelectModal}
                    onHide={() => setShowUsersSelectModal(!showUsersSelectModal) }
                />
                <InputModal
                    title="Create Message"
                    useTitle={true}
                    inputTitle={"To: " + selectedUsers?.map(x => (x.FirstName)).join(", ")}
                    input=""
                    onSubmit={onCreateMessageSubmit}
                    visible={showCreateMessageModal}
                    onHide={() => setShowCreateMessageModal(!showCreateMessageModal)}
                />
            </Tab.Container> 
        </div>
    );
}

export default Messages;