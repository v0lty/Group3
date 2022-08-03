import React, { useState, useContext, useEffect } from 'react';

import { AuthContext } from "./UserAuthentication";

import API from "./API";

export const UserComponent = props => {
    const authContext = useContext(AuthContext);

    useEffect(() => {
    }, [])

    return (
        <div className="m-0 p-0">
            <div className="row">
                <img className="profile-picture m-0 p-0" src={`../Pictures/${props?.user?.ProfilePicture.Path}`}></img>
            </div>
            <div className="row bg-gray">
                <b>{props?.user?.Name}</b>                
                <span>{props?.user?._Role}</span><br/>
                <span>POSTCOUNT</span>
            </div>
        </div>
    );
}

export default UserComponent;