import React, { useState, useContext } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './Menu.css';
import { AuthContext } from "./Context";
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/Dropdown';

export default function Menu() {
    const authContext = useContext(AuthContext);
    const [collapsed, setCollapsed] = useState(false);   

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">LOGO</NavbarBrand>
                    <NavbarToggler onClick={() => setCollapsed(!collapsed)} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/forum">Forum</NavLink>
                            </NavItem>
                            <NavItem>
                                {authContext.user == null && (
                                    <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                                )}
                                {authContext.user != null && (
                                    <DropdownButton variant="light" title={authContext?.user.Email} id="userButton">
                                        <Dropdown.Item>Profile</Dropdown.Item>
                                        <Dropdown.Item>Messages</Dropdown.Item>
                                        <Dropdown.Divider />
                                        <Dropdown.Item onClick={authContext.signOut}>Logout</Dropdown.Item>
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
