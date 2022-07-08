import React, { Component, useContext } from 'react';
import { Link } from 'react-router-dom';
import { AuthContext } from "./Context";

export default function Home() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            {authContext.user == null && (
                <div>
                    <h3>Hello stranger..</h3>
                    <Link to="/login">Login</Link>
                </div>
            )}
            {authContext.user != null && (
                <div>
                    <h3>Welcome {authContext?.user?.Name}!</h3>
                    <a>Id: {authContext?.user?.Id}</a><br/>
                    <a>Email: {authContext?.user?.Email}</a><br />
                    <a>Birthdate: {authContext?.user?.Birthdate}</a><br />
                </div>
            )}
        </div>
    );
}
