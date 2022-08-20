import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/Dropdown';
import { useHistory } from "react-router-dom";
import { AuthContext } from "./UserAuthentication";
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Button from 'react-bootstrap/Button';

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
                            <Form.Control type="text" placeholder="Enter email" required />
                        </Form.Group>
                        <Form.Group className="m-2" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Enter password" required />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>

            <Navbar className="navbar-expand-sm navbar-toggleable-sm">
                <NavbarBrand tag={Link} to="/" className="text-secondary fw-bold p-0 m-0"><h3>&emsp; &nbsp;<b>{`<CODE>`}</b>/talk</h3></NavbarBrand>
                <NavbarToggler onClick={() => setcollapsedMenu(!collapsedMenu)} />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsedMenu} navbar>
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} to="/" className="menu-item">Home</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/forum" className="menu-item">Forum</NavLink>
                        </NavItem>
                        <NavItem>
                            {(authContext.user != null && authContext.user.HasAuthority) && (
                                <NavLink tag={Link} to="/management" className="menu-item">Management</NavLink>
                            )}
                        </NavItem>
                        <NavItem>
                            {authContext.user == null && (
                                <NavLink tag={Link} to="/signup" className="menu-item">Sign Up</NavLink>
                            )}
                        </NavItem>
                        <NavItem>
                            {authContext.user == null ? (
                                <NavLink tag={Link} to="#" onClick={() => setCollapsedUser(!collapsedUser)} className="menu-item">Sign In</NavLink>
                            ) : (
                                    <Dropdown as={ButtonGroup}>
                                        <Dropdown.Toggle variant="light" className="menu-item" id="dropdown-custom-1">{authContext?.user.Name}</Dropdown.Toggle>
                                
                                <Dropdown.Menu className="menu-item">
                                            <Dropdown.Item onClick={() => routeChange(`/profile/${authContext?.user?.Id}`)} active ><i className="fa fa-gear" />  Profile</Dropdown.Item>
                                    <Dropdown.Item onClick={() => routeChange('/messages/null')}><i className="fa fa-envelope" /> Messages</Dropdown.Item>
                                    <Dropdown.Divider />
                                    <Dropdown.Item onClick={() => signOutUser()}><i className="fa fa-close" /> Sign out</Dropdown.Item>
                                </Dropdown.Menu>
                                </Dropdown>
                                )}
                        </NavItem>
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
}