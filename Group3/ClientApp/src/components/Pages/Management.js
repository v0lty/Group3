import React, { Component, useEffect, useState, useContext } from 'react';
import sortHook, { SortButton } from '../SortHook'
import { AuthContext } from "../UserAuthentication";
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form'
import API from "../API";
import { useHistory } from "react-router-dom";
import Modal from 'react-bootstrap/Modal';

export const Management = props => {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [users, setUsers] = useState([]);
    const [selectedUser, setSelectedUser] = useState(null);
    const [roles, setRoles] = useState([]);
    const [showRolesModel, setShowRolesModel] = useState(false);
    const [showCreateRoleModal, setShowCreateRoleModal] = useState(false);

    const { items, requestSort, sortConfig } = sortHook(
        users,
        props?.config
    )

    const getAllUsers = async () => {
        API.getAllUsers().then((users) => {
            setUsers(users);
        });
    }

    const getAllRoles = async () => {
        API.getAllRoles().then((roles) => {
            setRoles(roles);
            console.log(roles);
        });
    }

    useEffect(() => {
        getAllUsers();
        getAllRoles();
    }, [props])

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

    const onEditClick = (user) => {
        setShowRolesModel(!showRolesModel);
        setSelectedUser(user);
    }

    const onRolesSubmit = async (event) => {
        event.preventDefault();

        var checked = Array.from(document.getElementsByClassName('form-check-input')).filter(item => item.checked);
        if (checked == null
         || checked.length == 0) {
            alert("Select atleast one Role!");
            return;
        }

        API.setUserRoles({
            userId: selectedUser.Id,
            roleArrayString: checked.map(el => (el.id)).toString(),
        }).then(() => {
            setShowRolesModel(false);
            getAllUsers();
        });
    }

    const onCreateRoleSubmit = async (event) => {
        event.preventDefault();

        API.createRole({
            roleName: event.target.elements['roleNameInput'].value,
        }).then(() => {
            getAllRoles();
            setShowCreateRoleModal(false);
        });
    }

    const onDeleteRole = (role) => {
        API.deleteRole({
            roleId: role.Id,
        }).then(() => {
            getAllRoles();
        });
    }

    return (
        <div>
            <h3>Management</h3>
            <Tabs defaultActiveKey="users" className="mb-3 pt-3">
                <Tab eventKey="users" title="Users">
                    <FloatingLabel label="Search" className="mb-3">
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
                                <tr key={userIndex}>
                                    <td>
                                        <img className="profile-image-extra-small" src={`../Pictures/${user.ProfilePicture?.Path}`}></img>
                                    </td>
                                    <td>{user.FirstName}</td>
                                    <td>{user.LastName}</td>
                                    <td>{user.Email}</td>
                                    <td>{user.RoleString} </td>
                                    <td>
                                        <button className="btn btn-link text-info py-0" onClick={() => onEditClick(user) }>
                                            Edit Roles
                                        </button>
                                        <button className="btn btn-link text-info py-0" onClick={() => history.push(`/profile/${user.Id}`)}>
                                            Edit Profile
                                        </button>
                                        {authContext?.user?.Id != user?.Id && !user?.IsAdmin && (
                                            <button className="btn btn-link text-danger py-0" onClick={() => onRemoveClick(user.Id)}>
                                                Delete
                                            </button>
                                        )}
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </Tab>
                <Tab eventKey="roles" title="Roles">
                    <table className='table'>
                        <thead>
                            <tr>
                                <th><SortButton sortConfig={sortConfig} id="Name" onClick={() => requestSort('Name')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Users" onClick={() => requestSort('Users')} /></th>
                                <th className="tiny-th">
                                    <button className="btn btn-light text-info" id="add" onClick={() => setShowCreateRoleModal(!showCreateRoleModal)}>
                                        Create Role
                                    </button>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {roles?.map((role, roleIndex) =>
                                <tr key={roleIndex}>
                                    <td>{role.Name}</td>     
                                    <td>{role.UserRoles.map(x => (x.User.Name)).join(', ')}</td>
                                    <td>
                                        <button className="btn btn-link text-danger py-0" onClick={() => onDeleteRole(role)}>
                                            Delete
                                        </button>
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </Tab>
                <Tab eventKey="groups" title="Groups" disabled>
                </Tab>
            </Tabs>

            <Modal show={showRolesModel} onHide={() => setShowRolesModel(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Select Roles</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onRolesSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <Form.Group className="m-2">
                            <div id="rolesForm">
                                {roles?.map((role, roleIndex) =>
                                    <div className="form-check form-switch" key={roleIndex}>
                                        {selectedUser?.Roles?.includes(role.Name) ? (
                                            < input className="form-check-input" type="checkbox" id={role.Name} defaultChecked />
                                        ) : (
                                            < input className="form-check-input" type="checkbox" id={role.Name} />
                                        )}
                                        <label className="form-check-label">{role.Name}</label>
                                    </div>
                                )}
                            </div>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>

            <Modal show={showCreateRoleModal} onHide={() => setShowCreateRoleModal(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Create Role</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onCreateRoleSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <FloatingLabel label="Role Name" className="mb-3">
                            <Form.Control type="text" id="roleNameInput" />
                        </FloatingLabel>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default Management;