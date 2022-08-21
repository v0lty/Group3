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

export default function Messages() {
    const authContext = useContext(AuthContext);
    const [chats, setChats] = useState([]);
    const [chat, setChat] = useState(null);
    const [people, setPeople] = useState([]);
    const [peopleNames, setPeopleNames] = useState("");
    const [chatModalVisible, setChatModalVisible] = useState(false);
    const [peopleSelectModalVisible, setPeopleSelectModalVisible] = useState(false);
    const { id } = useParams();
    const [bottomElement, setBottomElement] = useState(null);

    useEffect(() => {
        if (id != null && id != "null") {
            const ids = [id];
            onPeopleSelectSubmit(ids);
        }
        updateChats();
        scrollToBottom();
    }, [id])

    const scrollToBottom = () => {        
        if (bottomElement != null) {          
            // TODO: This only works once for some reason
            bottomElement.scrollIntoView({ behavior: 'smooth', block: 'nearest', inline: 'start' });
        }
    }

    const updateChats = () => {
        API.getChats({
            userId: authContext?.user?.Id
        }).then((chats) => {
            setChats(chats);
            scrollToBottom();
        });
    };

    const onChange = (value) => {
        setValue(value);
    };

    const onReplay = (chat) => {
        setChat(chat);
        setPeopleNames(chat?.Users?.map(user => user.FirstName).toString());
        setChatModalVisible(true);        
    };

    const onCreateConversation = () => {
        setPeopleSelectModalVisible(!peopleSelectModalVisible);
    };

    const onChatSubmit = async (event, title, text) => {

        if (chat != null) {
            API.createChatMessage({
                userIdArray: chat?.Users.map(user => user.Id).toString(),
                aurthorId: authContext?.user.Id,
                chatId: chat.Id,
                text: text,
            }).then(() => {
                updateChats();
                setChatModalVisible(false);
            });
        }
        else {
            API.createChatMessage({
                userIdArray: people?.toString(),
                aurthorId: authContext?.user.Id,
                chatId: null,
                text: text,
            }).then(() => {
                updateChats();
                setChatModalVisible(false);
            });
        }

        setChat(null);
        setPeople(null);
    }

    const onPeopleSelectSubmit = async (users) => {
        setPeople(users);

        users?.forEach(id => {
            API.getUserById({
                userId: id,
            }).then((user) => {
                setPeopleNames(user.FirstName + ", " + peopleNames);
            })
        });
        
        setPeopleSelectModalVisible(false);
        setChatModalVisible(true);
    }

    const onDeleteClick = (message) => {
        // TODO: API function to delete message
    }

    return (
        <div className="context bg-white shadow">
            <h4>Conversations</h4><br />
            <Tab.Container defaultActiveKey="0">                
                <Row>                 
                    {/*BUTTONS*/}
                    <Col sm={4}>                        
                        <Nav variant="pills" className="flex-column border-bottom">
                            {chats.map((chat, chatIndex) =>   
                                <Nav.Item key={chatIndex} className="mb-2">
                                    <Nav.Link eventKey={chatIndex} onClick={() => scrollToBottom()}>
                                        {/*NAMES*/}
                                        {chat?.Users.map(user => user.Name).join(', ')} and You
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
                    {chats.map((chat, chatIndex) =>                        
                        <Tab.Content key={chatIndex}>
                            <Tab.Pane eventKey={chatIndex}>
                                <div className="">
                                    {chat?.Items.map((message, messageIndex) =>
                                    /*BUBBLE*/
                                    <div key={messageIndex} className={message?.Aurthor?.Id == authContext.user?.Id
                                            ? "row bubble-right mt-4"
                                            : "row bubble mt-4"}>
                                        {/*USER*/}
                                        <div className="col-3" style={{ width: 100 }}>                                        
                                            <div className="text-center p-2">
                                                {/*USERPICTURE*/}
                                                <img className="profile-image-small" src={`../Pictures/${message?.Aurthor.ProfilePicture?.Path}`}></img>                                           
                                                {/*USERNAME*/}
                                                {authContext?.user?.Id == message.Aurthor.Id ? (
                                                    <h5>You</h5>) : (                                       
                                                    <h5>{message.Aurthor.FirstName}</h5>
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
                                            {authContext?.user?.Id == message.Aurthor.Id && (
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
                                    <button className="btn btn-link border-0 bubble-right fw-bold mt-4 px-5" style={{ minHeight: 75 }} onClick={() => onReplay(chat)}>
                                        <FontAwesomeIcon icon={faReply} />
                                    </button>
                                </div>
                            </Tab.Pane>
                        </Tab.Content>                          
                        )}
                        <div style={{ float: "right", clear: "both" }} ref={(el) => { setBottomElement(el); }}>
                        </div>
                    </Col>
                </Row>
                <UserSelectModal
                    title="Select People"
                    onSubmit={onPeopleSelectSubmit}
                    visible={peopleSelectModalVisible}
                    onHide={() => { setPeopleSelectModalVisible(!peopleSelectModalVisible); }}
                />
                <InputModal
                    title="Create Message"
                    useTitle={true}
                    inputTitle={"To: " + peopleNames}
                    input=""
                    onSubmit={onChatSubmit}
                    visible={chatModalVisible}
                    onHide={() => { setChatModalVisible(!chatModalVisible); setChat(null); setPeopleNames(""); }}
                />
            </Tab.Container> 
        </div>
    );
}