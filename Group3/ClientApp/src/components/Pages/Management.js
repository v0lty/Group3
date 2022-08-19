import React, { Component, useEffect, useState, useContext } from 'react';
import sortHook, { SortButton } from '../SortHook';
import { AuthContext } from "../UserAuthentication";
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form';
import API from "../API";
import { useHistory } from "react-router-dom";
import Modal from 'react-bootstrap/Modal';
import moment from "moment";
import InputModal from '../InputModal';
import RichTextEditor from 'react-rte'; // https://github.com/sstur/react-rte

export const Management = props => {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [users, setUsers] = useState([]);
    const [roles, setRoles] = useState([]);
    const [selectedUser, setSelectedUser] = useState(null);
    const [selectedRole, setSelectedRole] = useState(null);    
    const [showRolesModel, setShowRolesModel] = useState(false);
    const [showBanUsereModal, setShowBanUsereModal] = useState(false);
    const [banSelected, setBanSelected] = useState(false);
    const [banEndDate, setBanEndDate] = useState(null);
    const [showCreateRoleModal, setShowCreateRoleModal] = useState(false);
    const [showEditRoleModal, setShowEditRoleModal] = useState(false);
    const [showCreateEventModal, setShowCreateEventModal] = useState(false);
    const [value, setValue] = useState(RichTextEditor.createValueFromString("", 'html'));
    
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

    const onSearchUsersChange = async (event) => {
        API.getUserByName({
            search: event.target.value,
        }).then((users) => {
            setUsers(users);
        });
    }

    const onEditUser = (user) => {
        setShowRolesModel(true);
        setSelectedUser(user);
    }

    const onBanUser = (user) => {
        setShowBanUsereModal(true);
        setSelectedUser(user);

        setBanSelected(user.LockoutEnabled);
        setBanEndDate(moment(user.LockoutEnd).format('YYYY-MM-DD'));
    }

    const onDeleteUser = (id) => {
        if (confirm("Are you sure you want to delete this user?")) {
            API.removeUser({
                userId: id,
            }).then(() => {
                getAllUsers();
            });
        }
    }

    const onEditUserRolesSubmit = async (event) => {
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
            getAllRoles();
        });
    }

    const onBanUserSubmit = async (event) => {
        event.preventDefault();
        console.log("ban");
        API.banUser({
            userId: selectedUser.Id,
            invokeBan: banSelected,
            endDate: banSelected ? event.target.elements['banEndDateInput'].value : null,
        }).then(() => {
            setShowBanUsereModal(false);
            getAllUsers();
            getAllRoles();
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

    const onEditRoleSubmit = async (event) => {
        event.preventDefault();

        API.editRole({
            roleId: selectedRole?.Id,
            roleName: event.target.elements['roleNameEditInput'].value,
        }).then(() => {
            getAllUsers();
            getAllRoles();
            setShowEditRoleModal(false);
        });
    }
    

    const onEditRole = (role) => {
        setSelectedRole(role);
        setShowEditRoleModal(true);
    }

    const onDeleteRole = (role) => {
        if (confirm("Are you sure you want to delete this role?")) {
            API.deleteRole({
                roleId: role.Id,
            }).then(() => {
                getAllUsers();
                getAllRoles();
            });
        }
    }

    const onEventSubmit = async (event) => {
        console.log("event");
        event.preventDefault();    
        
        API.createEvent({
            title: event.target.elements['eventTitleInput'].value,
            date: event.target.elements['eventDateInput'].value,
            text: value.toString('html'),
        }).then(() => {
        
        });
    }

//    const onEventSubmit = async (event) => {
//        console.log("event");
//        event.preventDefault();    
//        
//        API.createEvent({
//            title: event.target.elements['eventTitleInput'].value,
//            date: event.target.elements['eventDateInput'].value,
//            text: value.toString('html'),
//        }).then(() => {
//            setShowCreateEventModal(false);
//        });
//    }

    return (
        <div class="Main">
            <h3>Management</h3>
            <Tabs defaultActiveKey="users" className="mb-3 pt-3">
                <Tab eventKey="users" title="Users">
                    <FloatingLabel label="Search" className="mb-3">
                        <Form.Control type="text" id="searchInput" onChange={onSearchUsersChange} />
                    </FloatingLabel>
                    <table className='table'>
                        <thead>
                            <tr>
                                <th />
                                <th><SortButton sortConfig={sortConfig} id="FirstName" onClick={() => requestSort('FirstName')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="LastName" onClick={() => requestSort('LastName')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Email" onClick={() => requestSort('Email')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Banned" onClick={() => requestSort('Email')} /></th>
                                <th><SortButton sortConfig={sortConfig} id="Roles" onClick={() => requestSort('Roles')} /></th>
                                <th className="tiny-th">
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {users?.map((user, userIndex) =>
                                <tr key={userIndex}>
                                    <td>
                                        <img className="profile-image-extra-small" src={'../Pictures/${user.ProfilePicture?.Path}'}></img>
                                    </td>
                                    <td>{user.FirstName}</td>
                                    <td>{user.LastName}</td>
                                    <td>{user.Email}</td>
                                    <td>
                                        {user.LockoutEnabled ? (
                                            moment(user.LockoutEnd).format('YYYY/MM/DD HH:mm')
                                        ): (
                                            "False"
                                        )}
                                    </td>
                                    <td>{user.RoleString} </td>
                                    <td>

                                        <button className="btn btn-link text-info py-0" onClick={() => onEditUser(user) }>
                                            Edit Roles
                                        </button>
                                        <button className="btn btn-link text-info py-0" onClick={() => history.push(`/profile/${user.Id}`)}>
                                            Edit Profile
                                        </button>
                                        <button className="btn btn-link text-info py-0" onClick={() => onBanUser(user)}>
                                            Edit Ban
                                        </button>
                                        {authContext?.user?.Id != user?.Id && !user?.IsAdmin && (
                                            <button className="btn btn-link text-danger py-0" onClick={() => onDeleteUser(user.Id)}>
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
                                        <button className="btn btn-link text-info py-0" onClick={() => onEditRole(role)}>
                                            Edit
                                        </button>
                                        <button className="btn btn-link text-danger py-0" onClick={() => onDeleteRole(role)}>
                                            Delete
                                        </button>
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </Tab>
                <Tab eventKey="create event" title="Create Event">
                    <button className="btn btn-link text-success py-0 me-3" onClick={() => setShowCreateEventModal(true)}>Create a new Event</button>
                </Tab>  

            </Tabs>

            <Modal show={showCreateEventModal} onHide={() => setShowCreateEventModal(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Create Event</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onEventSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <FloatingLabel label="Title" className="mb-3"> 
                            <Form.Control type="text" id="eventTitleInput" required />
                        </FloatingLabel>
                        <FloatingLabel label="Event Date" className="mb-3">
                            <Form.Control type="date" id="eventDateInput" required />
                        </FloatingLabel>
                        <RichTextEditor id="eventTextInput" className="new-post-editor"
                            value={value}
                            onChange={(value) => setValue(value)}
                            autoFocus />
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>


            <Modal show={showRolesModel} onHide={() => setShowRolesModel(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Select Roles</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onEditUserRolesSubmit}>
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

            <Modal show={showBanUsereModal} onHide={() => setShowBanUsereModal(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Ban User</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onBanUserSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <div className="form-check form-switch mb-3">
                            <input className="form-check-input" type="checkbox" defaultChecked={banSelected} onChange={() => setBanSelected(!banSelected)} />
                            <label className="form-check-label">Invoke Ban</label>
                        </div>
                        {banSelected && 
                            <FloatingLabel label="End Date" className="mb-3">
                            <Form.Control type="date" id="banEndDateInput" value={banEndDate ? banEndDate : ''} required={banSelected} onChange={(e) => setBanEndDate(e.target.value) } />
                            </FloatingLabel>
                        }
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

            <Modal show={showEditRoleModal} onHide={() => setShowEditRoleModal(false)} backdrop="static">
                <Modal.Header closeButton>
                    <Modal.Title>Edit Role</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onEditRoleSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <FloatingLabel label="Role Name" className="mb-3">
                            <Form.Control type="text" id="roleNameEditInput" defaultValue={selectedRole?.Name} />
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