import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "./UserAuthentication";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Button from 'react-bootstrap/Button';
import API from "./API";

export default function Profile(props) {
    const authContext = useContext(AuthContext);

    const onFormSubmit = async (event) => {
        event.preventDefault();
        console.log('click Submit');

        console.log(event.target.elements);
        API.editUser( {
            email: event.target.elements['formEmail'].value,
            firstName: event.target.elements['formFirstName'].value,
            lastName: event.target.elements['formLastName'].value,
            birthdate: event.target.elements['formBirthdate'].value
        }).then((user) => {
            authContext.setUser(user);
        });
    }

    return (
        <div>
            <h1>Profile</h1>

            <Form onSubmit={onFormSubmit}>

                <Form.Group className="m-2" controlId="formEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control defaultValue={ authContext.user?.Email } />
                </Form.Group>
                <Form.Group className="m-2" controlId="formFirstName">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control defaultValue={authContext.user.FirstName} />
                </Form.Group>
                <Form.Group className="m-2" controlId="formLastName">
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control defaultValue={authContext.user.LastName} />
                </Form.Group>
                <Form.Group className="m-2" controlId="formBirthdate">
                    <Form.Label>Date Of Birth</Form.Label>
                    <Form.Control type="date" paceholder="yyyy/mm/dd" />
                </Form.Group>
                <Form.Group controlId="formPicture" className="m-2">
                    <Form.Label>Select profile picture</Form.Label>
                    <Form.Control type="file" />
                </Form.Group>
                <Button className="m-2" type="submit">Save User</Button>
            </Form>
        </div>
    );
}


//<div className="pt-3">
//    <h3>Welcome {authContext?.user?.Name}!</h3>
//    <br />
//    <span>Id: {authContext?.user?.Id}</span><br />
//    <span>Email: {authContext?.user?.Email}</span><br />
//    <span>Birthdate: {authContext?.user?.Birthdate}</span><br />
//    <span>Pictures:</span><br /> {
//        authContext?.user?.Pictures?.map(pic =>
//            <div key={pic?.Id}><span>{pic.Path}</span><br /></div>
//        )
//    }
//    <span>Roles:</span><br /> {
//        authContext?.user?.UserRoles?.map(userrole =>
//            <div key={userrole?.Role.Id}><span>{userrole.Role.Name}</span><br /></div>
//        )
//    }
//    <br />
//</div>