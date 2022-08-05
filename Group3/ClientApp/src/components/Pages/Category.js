import React, { useContext, useState, useEffect } from 'react';
import AuthContext from "../UserAuthentication";
import ListGroup from 'react-bootstrap/ListGroup';
import API from "../API";
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Badge from 'react-bootstrap/Badge';
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";

export const Category = props => {
    const authContext = useContext(AuthContext);
    const [modalVisible, setModalVisible] = useState(false);
    const [category, setCategory] = useState(props?.category);
    const history = useHistory();
    const { id } = useParams();

    useEffect(() => {
        if (props.category == null) {
            // URL
            updateCategory(id);
        }
        else {
            setCategory(props?.category);
        }
        
    }, [id])

    const updateCategory = async (id) => {
        API.getCategoryById({
            categoryId: id,
        }).then((category) => {
            setCategory(category);
        });
    }

    const onTopicOpen = (id) => {
        history.push('/topic/' + id);
    }

    const onTopicCreate = () => {
        setModalVisible(true);
    }

    const onTopicSubmit = async (event) => {
        event.preventDefault();

        API.createTopic({
            name: event.target.elements['formName'].value,
            categoryId: category?.Id
        }).then((user) => {
            setModalVisible(false);
            updateCategory(props.category != null ? props.category.Id : id);
        });
    }

    return (
        <div>
            <h5 className="fw-bold">{category?.Name}</h5>
            <ListGroup as="ol" className="pb-2">
                {category?.Topics.map((topic, topicIndex) =>
                    <ListGroup.Item key={topicIndex} as="li" className="d-flex justify-content-between align-items-start border-0 bg-gray m-1 mx-3">
                        <div className="me-auto">
                            <div className=""><button className="btn btn-link fw-bold m-0 p-0" onClick={() => onTopicOpen(topic.Id)}>{topic.Name}</button></div>
                            {topic.Description != null ? topic.Description : "No description" }
                        </div>         
                        <Badge bg="dark" pill>
                            Posts: {topic.PostsCount}
                        </Badge>                        
                    </ListGroup.Item>
                )}
            </ListGroup>     
            {authContext.user != null && 
            <button className="btn btn-link" onClick={onTopicCreate}>Create a new Topic in {category?.Name}</button>
            }
            <Modal show={modalVisible} onHide={() => setModalVisible(false)} backdrop={false}>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Create Topic
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onTopicSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <Form.Group className="m-2" controlId="formName">
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" required />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default Category;