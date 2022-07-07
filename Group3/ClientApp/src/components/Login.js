import React, { useContext } from 'react';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { Redirect } from 'react-router-dom'
import { AuthContext } from "./Context";
import axios from 'axios'

export default function Login() {
    const authContext = useContext(AuthContext);

    const onFormSubmit = async (e) => {
        e.preventDefault();

        await axios.post('http://localhost:13021/API/SignIn', null, {
            params: {
                email: e.target.elements['formEmail'].value,
                password: e.target.elements['formPassword'].value
            }
        }).then((response) => {
            const user = JSON.parse(response.data);
            authContext.signIn(user);

        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response?.data?.responseText);
            authContext.signOut();
        });
    }

    return (
        <div>
            {authContext.user == null && (
                <Form onSubmit={onFormSubmit}>
                    <Form.Group className="m-2" controlId="formEmail">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="text" required />
                    </Form.Group>
                    <Form.Group className="m-2" controlId="formPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" required />
                    </Form.Group>
                    <Button className="m-2" type="submit">Send</Button>
                </Form>
            )}
            {authContext.user != null && (               
                <Redirect to='/' />
            )}
        </div>
    );
}
