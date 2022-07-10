import React, { Components, useEffect, useState, useContext } from 'react';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { AuthContext } from "./UserAuthentication";

export function PostForm(props) {
    const authContext = useContext(AuthContext);

    return (
        <Form onSubmit={props.onSubmit}>
            <Form.Group className="m-2" controlId="formTopic">
                <Form.Label>Topic</Form.Label>
                <Form.Select className="p-2 border border-info rounded w-100" defaultValue='0' required>
                    {props.topics?.map((topic, index) =>
                        <option key={topic.Id} value={topic.Id}>{topic.Name}</option>
                    )}
                </Form.Select>
            </Form.Group>
            <Form.Group className="m-2" controlId="formText">
                <Form.Label>Text</Form.Label>
                <Form.Control type="text" required />
            </Form.Group>
            <Button className="m-2" type="submit">Send</Button>
        </Form>
    );
}
