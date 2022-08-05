﻿import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/Dropdown';
import { useHistory } from "react-router-dom";
import { AuthContext } from "./UserAuthentication";
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'
import FloatingLabel from 'react-bootstrap/FloatingLabel';

export default function Menu() {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [collapsedMenu, setcollapsedMenu] = useState(true);
    const [collapsedUser, setCollapsedUser] = useState(true);

    function routeChange(path) {
        history.push(path);
    }

    useEffect(() => {
        API.getCurrentUser().then((user) => {
            authContext.setUser(user)
        });
    }, [])

    const signOutUser = async () => {
        API.signOut().then(() => {
            authContext.setUser(null);
            routeChange('/');
        });
    }

    const submitSignIn = async (e) => {
        e.preventDefault();

       API.signIn({
            email: e.target.elements['formEmail'].value,
            password: e.target.elements['formPassword'].value
        }).then((user) => {
            authContext.setUser(user);
            setCollapsedUser(true);
        });
    }

    return (
        <header className="border-bottom p-2 py-0">
            <Modal show={!collapsedUser} onHide={() => setCollapsedUser(true)} backdrop={false}>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Sign in
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={submitSignIn}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <Form.Group className="m-2" controlId="formEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="text" required />
                        </Form.Group>
                        <Form.Group className="m-2" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" required />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>

            <Navbar className="navbar-expand-sm navbar-toggleable-sm">     
                <NavbarBrand tag={Link} to="/" className="text-secondary fw-bold">  <img src={require('./Logotype/CODE-TALK2.jpg')} /></NavbarBrand>
                <NavbarToggler onClick={() => setcollapsedMenu(!collapsedMenu)} />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsedMenu} navbar>
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} to="/"><h7 style={{ color: "#1c4966" }}>HOME</h7></NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/forum"><h7 style={{ color: "#1c4966" }}>FORUM</h7></NavLink>
                        </NavItem>
                        <NavItem>
                            {(authContext.user != null && authContext.user.HasAuthority) && (
                                <NavLink tag={Link} to="/managment"><h7 style={{ color: "#1c4966" }}>MANAGEMENT</h7></NavLink>
                            )}
                        </NavItem>
                        <NavItem>
                            {authContext.user == null && (
                                <NavLink tag={Link} to="/signup"><h7 style={{ color: "#1c4966" }}>SIGN UP</h7></NavLink>
                            )}                            
                        </NavItem>
                        <NavItem>
                            {authContext.user == null && (
                                <NavLink tag={Link} to="#" onClick={() => setCollapsedUser(!collapsedUser)}><h7 style={{ color: "#1c4966" }}>SIGN IN</h7></NavLink>
                            )}
                            {authContext.user != null && (
                                <DropdownButton variant="link" title={authContext?.user.Name} id="userButton">
                                    <Dropdown.Item onClick={() => routeChange('/profile')} ><i className="fa fa-gear" />  <h7 style={{ color: "#1c4966" }}>PROFILE</h7></Dropdown.Item>
                                    <Dropdown.Item onClick={() => routeChange('/messages')}><i className="fa fa-envelope" /> <h7 style={{ color: "#1c4966" }}>MESSAGES</h7></Dropdown.Item>
                                    <Dropdown.Divider />
                                    <Dropdown.Item onClick={() => signOutUser()}><i className="fa fa-close" /> <h7 style={{ color: "#1c4966" }}>SIGN OUT</h7></Dropdown.Item>
                                </DropdownButton>
                            )}   
                        </NavItem>
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
}