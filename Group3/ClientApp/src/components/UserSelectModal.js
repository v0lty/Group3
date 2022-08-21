﻿import React, { useState, useContext, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal'
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form'
import API from "./API";
import { AuthContext } from "./UserAuthentication";

export const UserSelectModal = props => {
    const authContext = useContext(AuthContext);
    const [modalVisible, setModalVisible] = useState(props.visible);
    const [users, setUsers] = useState([]);

    useEffect(() => {
        API.getAllUsers().then((users) => {
            setUsers(users);
        });
    }, [])

    if (props.visible !== modalVisible) {
        setModalVisible(props.visible);
    }

    const onSearchChange = async (event) => {
        API.getUserByName({
            search: event.target.value,
        }).then((users) => {
            setUsers(users);
        });
    }

    const onSelectSubmit = async (event) => {
        event.preventDefault();
        var children = Array.from(event.target.getElementsByClassName('form-check-input'));
        var checked = children.filter(item => item.checked);
        if (checked == null || checked.length == 0) {
            alert("Select atleast one User!");
            return;
        }
        var ids = checked.map(el => (users[el.id]));
        props?.onSubmit(ids);
    }

    return (
        <Modal show={modalVisible} onHide={props?.onHide} backdrop={false} size="lg" centered contentClassName="modal-height">
            <Modal.Header closeButton>
                <Modal.Title>
                    {props?.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <FloatingLabel label="Search" className="mb-3">
                    <Form.Control type="text" placeholder="Search" id="searchInput" onChange={onSearchChange } />
                </FloatingLabel>
                <Form onSubmit={onSelectSubmit}>
                    <input type="submit" id="submitInput" className="d-none" />
                    <Form.Group className="m-2">
                        <div id="userForm">
                            {users?.map((user, userIndex) =>
                                <div className="form-check form-switch" key={userIndex}>
                                    <input className="form-check-input" type="checkbox" id={userIndex} />
                                    <label className="form-check-label">{user.Name}</label>
                                </div>
                            )}
                        </div>     
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <label htmlFor="submitInput" className="btn btn-primary">Select</label>
            </Modal.Footer>
        </Modal>
    );
}

export default UserSelectModal;