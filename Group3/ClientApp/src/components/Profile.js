import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "./UserAuthentication";

export default function Profile() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            <h1>Profile</h1>
        </div>
    );
}
