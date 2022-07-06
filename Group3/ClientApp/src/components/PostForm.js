
import Form from 'react-bootstrap/Form'
import React, { Components, useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';

export function PostForm(props) {
    return (
        <Form onSubmit={() => props.onSubmit}>
            <Form.Group controlId="formText">
                <Form.Label>Text</Form.Label>
                <Form.Control type="text"required/>
            </Form.Group>
            <Button type="submit">Send</Button>
        </Form>
        );
}
