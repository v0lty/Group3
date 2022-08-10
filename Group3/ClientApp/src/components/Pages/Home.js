import React, { useContext } from 'react';
import { AuthContext } from "../UserAuthentication";
import News from "./News";

export default function Home() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            {authContext.user != null ? (
                <h3>Welcome back {authContext.user.Name}!</h3>
            ) : (
                <h3>Hello stranger..</h3>
            )}
            <br/>
            <News />
        </div>


    );
}