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

export default function Messages() {
    const authContext = useContext(AuthContext);
    const [chats, setChats] = useState([]);
    const [chat, setChat] = useState(null);
    const [people, setPeople] = useState([]);
    const [chatModalVisible, setChatModalVisible] = useState(false);
    const [peopleSelectModalVisible, setPeopleSelectModalVisible] = useState(false);
    
    const [bottomElement, setBottomElement] = useState(null);

    useEffect(() => {
        updateChats();
        scrollToBottom();
    }, [])

    const scrollToBottom = () => {        
        if (bottomElement != null) {            
            console.log("scrolling..");
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
        setChatModalVisible(!chatModalVisible);
        setChat(chat);
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
            console.log(people);
            console.log(people?.toString());
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
        setPeopleSelectModalVisible(false);
        setChatModalVisible(true);
    }

    return (   
        <Tab.Container defaultActiveKey="0">
            <h2>Conversations</h2><br />
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
                    <button className="btn btn-secondary w-100 mt-3 text-start" onClick={onCreateConversation}>New Conversation</button>
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
                                        ? "row chat-bubble speech-bubble-right"
                                        : "row chat-bubble speech-bubble-left"}>
                                    {/*USER*/}
                                    <div className="col-3" style={{ width: 100 }}>                                        
                                        <div className="text-center p-2">
                                            {/*USERPICTURE*/}
                                            <img className="profile-image-small" src={`../Pictures/${message?.Aurthor.ProfilePicture?.Path}`}></img>                                           
                                            {/*USERNAME*/}
                                            {authContext?.user?.Id == message.Aurthor.Id ? (
                                                <h5>You</h5> ) : (                                                                  
                                                <h5>{message.Aurthor.FirstName}</h5>                                                                   
                                            )}                                             
                                        </div>
                                    </div>
                                    <div className="col">
                                        <div className="row">
                                            {/*TIME*/}
                                            <div>
                                                <span className="float-end">{moment(message.Time).fromNow()}</span>
                                            </div>
                                                {/*TEXT*/}
                                                <div dangerouslySetInnerHTML={{ __html: message.Text }} />
                                        </div>
                                    </div>                                     
                                </div>
                                )}
                            </div>
                            {/*MESSAGE BUTTON*/}
                            <div className="d-flex justify-content-end w-100">
                                <button className="btn border-0 button-speech-bubble fw-bold" onClick={() => onReplay(chat)}>Replay</button>
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
                useTitle={chat != null}
                inputTitle={chat != null ? "To: " + chat?.Users?.map(user => " " + user.FirstName).toString() : ""}
                input=""
                onSubmit={onChatSubmit}
                visible={chatModalVisible}
                onHide={() => { setChatModalVisible(!chatModalVisible); setChat(null); }}
            />
        </Tab.Container>           
    );
}
