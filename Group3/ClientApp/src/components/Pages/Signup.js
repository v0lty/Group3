import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "../UserAuthentication";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Button from 'react-bootstrap/Button';
import API from "../API";
import { useHistory } from "react-router-dom";
import FloatingLabel from 'react-bootstrap/FloatingLabel';


export default function Signup(props) {
    const authContext = useContext(AuthContext);
    const history = useHistory();

    const onFormSubmit = async (event) => {
        event.preventDefault();

        API.createUser({
            firstName: event.target.elements['firstnameInput'].value,
            lastName: event.target.elements['lastnameInput'].value,
            birthdate: event.target.elements['dateofbirthInput'].value,
            location: event.target.elements['locationInput'].value,
            email: event.target.elements['emailInput'].value,
            password: event.target.elements['passwordInput'].value,
            confirm: event.target.elements['confirmInput'].value   
        }).then((user) => {
            authContext.setUser(user);
            alert("Account has been created!");
            history.push("/");
        });
    }

    return (
        <div>
            <h1>Create account</h1>
            <Form className="sidebar-text" onSubmit={onFormSubmit}>
               
                <FloatingLabel label="Firstname" className="mb-3">
                    <Form.Control type="text" placeholder="Enter Firstname" id="firstnameInput"  required/>
                    </FloatingLabel>
                <FloatingLabel label="Lastname" className="mb-3">
                    <Form.Control type="text" placeholder="Enter Lastname" id="lastnameInput" required />
                </FloatingLabel>
                <FloatingLabel label="DateOfBirth" className="mb-3">
                    <Form.Control className="sidebar-text" type="date" placeholder="yyyy/mm/dd" id="dateofbirthInput" required />
                </FloatingLabel>
                <FloatingLabel label="Location" className="mb-3">
                    <Form.Control type="text" placeholder="Enter Location" id="locationInput" required />
                </FloatingLabel>
                <FloatingLabel label="Email" className="mb-3">
                    <Form.Control type="Emali" placeholder="Enter Email" id="emailInput" required />
                </FloatingLabel>
                <FloatingLabel label="Password" className="mb-3">
                    <Form.Control type="password" placeholder="Enter Password" id="passwordInput" required />
                </FloatingLabel>

                <FloatingLabel label="Confirm" className="mb-3">
                    <Form.Control type="password" placeholder="Confirm Password" id="confirmInput" required />
                </FloatingLabel>

                <Button className="m-2" type="submit">Register</Button>
            </Form>
        </div>
    );
}