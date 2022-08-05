import React, { useState, useContext, useEffect } from 'react';
import API from "../API";
import { AuthContext } from "../UserAuthentication";

export default function Messages() {
    const authContext = useContext(AuthContext);
    const [chats, setChats] = useState([]);

    useEffect(() => {
        API.getChats({
            userId: authContext.user.Id
        }).then((chats) => {
            setChats(chats);
        });
    }, [])

    const onChange = (value) => {
        setValue(value);
    };

    return (
        <div>            
            <h2>Messages</h2><br/>
            {chats.map((chat, chatIndex) =>
                <div key={chatIndex} className="border rounded m-2 p-3">
                    <span className="text-danger">{chat?.Users.map(user => user.Name).join(', ')}</span><br /><br />
                    {chat?.Items.map((message, messageIndex) =>
                        <div key={messageIndex}>
                            <span className={message?.Aurthor?.Id == authContext.user?.Id ? "text-info" : "text-muted"}>
                                <i> {message?.Time}</i> - 
                                <b> {message?.Aurthor?.Name}</b> :
                                <a> {message?.Text}</a>
                            </span>
                        </div>
                    )}
                </div>
            )}           
        </div>        
    );
}
