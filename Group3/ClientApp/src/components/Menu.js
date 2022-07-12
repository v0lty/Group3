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
        <header>
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

            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/"><b>LOGO</b></NavbarBrand>
                    <NavbarToggler onClick={() => setcollapsedMenu(!collapsedMenu)} />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsedMenu} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} to="/forum">Forum</NavLink>
                            </NavItem>
                            <NavItem>
                                {authContext.user == null && (
                                    <NavLink tag={Link} to="#" onClick={() => setCollapsedUser(!collapsedUser)}>Login</NavLink>
                                )}
                                {authContext.user != null && (
                                    <DropdownButton variant="light" title={authContext?.user.Email} id="userButton">
                                        <Dropdown.Item onClick={() => routeChange('/profile')}>Profile</Dropdown.Item>
                                        <Dropdown.Item onClick={() => routeChange('/messages')}>Messages</Dropdown.Item>
                                        <Dropdown.Divider />
                                        <Dropdown.Item onClick={() => signOutUser()}>Logout</Dropdown.Item>
                                    </DropdownButton>
                                )}   
                            </NavItem>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );
}