import React, { useState, useContext, useEffect } from 'react';
// user 
import { AuthContext } from "./UserAuthentication";
// front-end API
import API from "./API";

export default function Template() { 
    // user hook (global state)
    const authContext = useContext(AuthContext);
    // state
    const [something, setSomething] = useState([]);

    const updateSomething = async () => {
        // GET
        API.getSomething().then((data) => {
            setSomething(data);
        });
        // POST
        API.getTopicById({
            someValue: value,
        }).then((data) => {
            setSomething(data);
        });
    }

    useEffect(() => {
        // ~ onLoad    
    }, [])

    return (
        <div>
            <a>{authContext.user.Name}</a>
        </div>
    );
}