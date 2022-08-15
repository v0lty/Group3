import React, { Component, useEffect, useState, useContext  } from 'react';
import sortHook, { SortButton } from '../SortHook'
import { AuthContext } from "../UserAuthentication";
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form'
import API from "../API";
import { useHistory } from "react-router-dom";

var isItUserGroup = false;

export const Management = props => {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [users, setUsers] = useState([]);

    const { items, requestSort, sortConfig } = sortHook(
        users,
        props?.config
    )

    const getAllUsers = async () => {
        API.getAllUsers().then((users) => {
            setUsers(users);
        });
    }

    useEffect(() => {
        getAllUsers();
    }, [])

    const onSearchChange = async (event) => {
        API.getUserByName({
            search: event.target.value,
        }).then((users) => {
            setUsers(users);
        });
    }

    const onRemoveClick = (id) => {
        API.removeUser({
            userId: id,
        }).then(() => {
            getAllUsers();
        });
    }

    const onCategorySubmit = (event, title, text) => {
        API.createCategory({
            name: title,
            description: text,
            userGroup: isItUserGroup,
        }).then(() => {
            // setInput("");        copied from kim's post create code in the subject.js that doesn't seem to be useful here
            // props?.onUpdate();
            setModalVisible(!modalVisible)
        });
    }

    return (
        <div>
            <h3>Management</h3>
            <Tabs defaultActiveKey="users" className="mb-3 pt-3">
                <Tab eventKey="users" title="Users">
                    <FloatingLabel label="Filter Users" className="mb-3">
                        <Form.Control type="text" id="searchInput" onChange={onSearchChange} />
                    </FloatingLabel>
                    <table className='table'>
                        <thead>
                            <tr>
                                <th />
                                <th><SortButton sortConfig={sortConfig} id="FirstName" onClick={() => requestSort('FirstName')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="LastName" onClick={() => requestSort('LastName')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Email" onClick={() => requestSort('Email')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Roles" onClick={() => requestSort('Roles')} /></th>
                                <th className="tiny-th">
                                    
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                           {users?.map((user, userIndex) =>
                               <tr key={user.Id}>
                                   <td>
                                       <img className="profile-image-extra-small" src={`../Pictures/${user.ProfilePicture?.Path}`}></img>
                                    </td>
                                   <td>{user.FirstName}</td>
                                   <td>{user.LastName}</td>
                                   <td>{user.Email}</td>
                                   <td>{user.RoleString} </td>
                                   <td>
                                       <button className="btn btn-light text-info py-0" onClick={() => history.push(`/user/${user.Id}`)}>
                                           &#x2630;
                                       </button>
                                       {/*TODO: Admins can't be deleted by other Admis? (who's superior?)*/}
                                       {authContext?.user?.Id != user?.Id && !user?.IsAdmin && (
                                           <button className="btn btn-light text-danger py-0" onClick={() => onRemoveClick(user.Id) }>
                                                &#x2715;
                                            </button>
                                        )}                               
                                   </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </Tab>
                <Tab eventKey="news" title="News">
                    <p>profile</p>
                </Tab>
                <Tab eventKey="groups" title="Groups" disabled>
                </Tab>
            </Tabs>
        </div>
    );
}

export default Management;