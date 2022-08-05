import React, { useContext } from 'react';

export const UserComponent = props => {

    return (
        <div>     
            <div className="row m-0">
                <img className="profile-picture" src={`../Pictures/${props?.user?.ProfilePicture?.Path}`}></img>
            </div>
            <div className="row m-0">
                <h5>{props?.user?.Name}</h5>                
                <span className="text-info">{props?.user?.RoleString}</span><br/>
                <span>Posts: { Math.floor(Math.random() * 500) }</span>
            </div>
        </div>
    );
}

export default UserComponent;