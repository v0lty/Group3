import React, { useState, useContext, useEffect, createContext  } from 'react';
import { AuthContext, UserModalHook } from "../UserAuthentication";
import moment from "moment";
import API from "../API";
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCommenting } from '@fortawesome/free-solid-svg-icons'

// URL
export const UserPath = () => {
    const { id } = useParams();
    const history = useHistory();
    const [user, setUser] = useState(null);

    const updateUser = () => {
      
        API.getUserById({
            userId: id
        }).then((user) => {
            setUser(user);
        });
    };

    useEffect(() => {       
        updateUser();
    }, [id])

    return (
        <div>
            <User user={user} />
        </div>
    );
}

export const User = props => {
    const authContext = useContext(AuthContext);
    const history = useHistory();

    const onRemoveClick = (id) => {
        API.removeUser({
            userId: id,
        }).then(() => {
            history.push("/");
        });
    }

    return (
        <div className="context bg-white shadow">
            <h3>{props?.user?.Name}</h3>            
            <div className="d-flex flex-row">
                <div className="p-2" >
                    <img className="" loading="lazy" src={`../Pictures/${props?.user?.ProfilePicture?.Path}`}></img>
                </div>
                <div className="p-2">
                    <span>
                        Date of birth:<br />
                        <b>{moment((props?.user?.Birthdate)).format("DD/MM/yyyy")}</b>
                        <br />
                        From:<br />
                        <b>{props?.user?.Location}</b>
                        <br />
                        E-mail:<br />
                        <b>{props?.user?.Email}</b>
                        <br />
                        Role:<br />
                        <b className="text-info">{props?.user?.RoleString}</b>
                        <br />
                    </span>
                </div>
            </div>

            {authContext?.user?.Id != props?.user?.Id && (
                <div className="d-flex align-items-start">
                    <button className="btn btn-link" onClick={() => history.push(`/messages/${props?.user?.Id}`)}>
                        <FontAwesomeIcon icon={faCommenting} />
                    </button>
                </div>
            )}

            {authContext?.user?.HasAuthority && !props?.user?.IsAdmin && authContext?.user?.Id != props?.user?.Id && (
                <div className="row">
                    <a className="btn-link" onClick={() => history.push(`/profile/${props?.user?.Id}`)}>Edit User</a>
                    <a className="btn-link" onClick={() => onRemoveClick(props?.user?.Id)}>Remove User</a>
                </div>
            )}

        </div>
    );
}

export default User;