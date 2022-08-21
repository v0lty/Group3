import React, { useState, useContext, useEffect, createContext } from 'react';
import { AuthContext, UserModalHook } from "./UserAuthentication";
import { useHistory } from "react-router-dom";

export const UserGroup = props => {
    const authContext = useContext(AuthContext);
    const history = useHistory();

    return (
        <div className="">
            <div className="d-flex align-items-start">
                {props?.users?.map((user, userIndex) =>
                    <img key={userIndex} className="profile-image-extra-small user-group" src={`../Pictures/${user?.ProfilePicture?.Path}`} style={{ left: userIndex * -15 }}></img>                
                )}
            </div>
            <div>
                <a>{props?.users?.map(x => (x.FirstName)).join(", ")}</a>
            </div>
        </div>
        
    );
}

export default UserGroup;