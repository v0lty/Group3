import React, { useContext } from 'react';
import { AuthContext } from "./UserAuthentication";
import News from "./News";

export default function Home() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            <h3>Hello {authContext.user != null ? authContext.user.Name + "!" : "..."}</h3>
            <News />
        </div>
    );
}

