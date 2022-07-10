import React, { useContext } from 'react';
import { AuthContext } from "./UserAuthentication";

export default function Messages() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            <h1>Messages</h1>
        </div>
    );
}
