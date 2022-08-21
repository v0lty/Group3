import React, { useContext } from 'react';
import { AuthContext } from "../UserAuthentication";
import News from "./News";

export default function Home() {
    const authContext = useContext(AuthContext);

    if (!authContext.initialed) {
        return <div />
    }
    else { 
        return (
            <div className="context bg-white shadow">
                {authContext.user != null ? (
                    <div className="text-muted">
                        <h3 className="text-dark">Welcome back {authContext.user.Name},</h3>
                        <h5><span>Keep up to date by checking out the latest <span className="text-news"><b>news</b></span> and <span className="text-events"><b>events</b></span>!</span></h5>
                    </div>
                ) : (
                    <div className="text-muted">
                        <h3 className="text-dark">Hello stranger,</h3>
                            <h5>Please Sign in or Sign up to get full access to our context!</h5>
                    </div>
                )}
                <br/>
                <News />
            </div>
        );
    }
}