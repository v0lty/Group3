import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "./UserAuthentication";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Button from 'react-bootstrap/Button';
import API from "./API";
import { useHistory } from "react-router-dom";

export default function Signup(props) {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const onFormSubmit = async (event) => {
        event.preventDefault();
        console.log('click Submit');

        console.log(event.target.elements);
        API.createUser({
            firstName: event.target.elements['formFirstName'].value,
            lastName: event.target.elements['formLastName'].value,
            birthdate: event.target.elements['formBirthdate'].value,
            email: event.target.elements['formEmail'].value,
            password: event.target.elements['formPassword'].value,
            confirm: event.target.elements['formConfirm'].value   

        }).then((user) => {
            authContext.setUser(user);
            alert("Account has created");
            history.push("/");
        });
    }

    return (
        <div>
            <h1>Create account</h1>

            <Form onSubmit={onFormSubmit}> 
                <Form.Group className="m-2" controlId="formFirstName">
                    <Form.Label>FirstName</Form.Label>
                    <Form.Control />
                </Form.Group>
                <Form.Group className="m-2" controlId="formLastName">
                    <Form.Label>LastName</Form.Label>
                    <Form.Control />
                </Form.Group>
                <Form.Group className="m-2" controlId="formBirthdate">
                    <Form.Label>Date Of Birth</Form.Label>
                    <Form.Control type="date" placeholder="YYYY/MM/DD"/>
                </Form.Group>
               
                <Form.Group className="m-2" controlId="formEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control />
                </Form.Group>
                <Form.Group className="m-2" controlId="formPassword">
                    <Form.Label>Password</Form.Label>

                    <Form.Control type="password" />
                </Form.Group>
                <Form.Group className="m-2" controlId="formConfirm">
                    <Form.Label>Confirm</Form.Label>
                    <Form.Control type="password" />
                </Form.Group>
                <Form.Group controlId="formPicture" className="m-2">
                    <Form.Label>Select profile picture</Form.Label>
                    <Form.Control type="file" />
                </Form.Group>
                <Button className="m-2" type="submit">Submit</Button>
            </Form>
        </div>
    );
}
