import React, { useContext } from 'react';
import { AuthContext } from "./UserAuthentication";

export default function Home() {
    const authContext = useContext(AuthContext);

    return (
        <div>
          <h1>Hello..</h1>
        </div>
    );
}

