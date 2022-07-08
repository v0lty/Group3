import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./Context";
import axios from 'axios'


export default function Profile() {
    const authContext = useContext(AuthContext);
    const [user, setUser] = useState([]);
    const baseURL = 'http://localhost:13021/API/';

    // TEST FOR USER COOKIE

    const getUser = async () => {

        await axios.get(baseURL + 'GetUser').then((response) => {
            setUser(JSON.parse(response.data));
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
            setUser([]);
        });
    }

    useEffect(() => {
        getUser();
    }, [])


    return (
        <div>
            <h1>Profile</h1>        
            <a>Name: {user?.Name}</a><br />
            <a>Id: {user?.Id}</a><br />
            <a>Email: {user?.Email}</a><br />
            <a>Birthdate: {user?.Birthdate}</a><br />     
        </div>
    );
}
