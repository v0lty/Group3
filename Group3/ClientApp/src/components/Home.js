import React, { useContext } from 'react';
import { AuthContext } from "./UserAuthentication";

export default function Home() {
    const authContext = useContext(AuthContext);

    return (
        <div>
            {authContext.user == null ? (
                <div/>
                ) : (
                <div className="pt-3">
                    <h3>Welcome {authContext?.user?.Name}!</h3>
                    <br />
                    <span>Id: {authContext?.user?.Id}</span><br/>
                    <span>Email: {authContext?.user?.Email}</span><br />
                    <span>Birthdate: {authContext?.user?.Birthdate}</span><br />
                    <span>Pictures:</span><br /> {
                        authContext?.user?.Pictures?.map(pic =>
                            <div><span>{pic.Path}</span><br/></div>
                        )
                    }
                    <span>Roles:</span><br /> {
                        authContext?.user?.UserRoles?.map(userrole =>
                            <div><span>{userrole.Role.Name}</span><br/></div>
                        )
                    }
                   <br />
                </div>
            )}
        </div>
    );
}

