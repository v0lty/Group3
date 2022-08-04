import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { PostTable } from './PostTable'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { AuthContext } from "./UserAuthentication";
import RichTextEditor from 'react-rte'; // https://github.com/sstur/react-rte
import PostComponent from './PostComponent';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import { useHistory } from "react-router-dom";
import Modal from 'react-bootstrap/Modal'

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);
    const [collapsedTopicModal, setCollapsedTopicModal] = useState(true);
    const [activeCategory, setActiveCategory] = useState(null);
    const history = useHistory();

    const updateCategories = async () => {
        API.getAllCategories().then((categories) => {
            setCategories(categories);
        });
    }

    useEffect(() => {
        updateCategories();
    }, [])

    function routeChange(path) {
        history.push(path);
    }

    const onTopicClick = (id) => {
        console.log(id);
        routeChange('/topic/' + id);
    }

    const submitTopic = async (e) => {
        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }
        e.preventDefault();
        console.log(e.target.elements['formName'].value);
        console.log(activeCategory);
        API.createTopic({
            name: e.target.elements['formName'].value,
            categoryId: activeCategory
        }).then((user) => {
            setCollapsedTopicModal(true);
            updateCategories();
        });
    }

    return (
        <div>
            <Modal show={!collapsedTopicModal} onHide={() => setCollapsedTopicModal(true)} backdrop={false}>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Create Topic
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={submitTopic}>
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

            {categories.map((category, categoryIndex) =>
                <div key={categoryIndex} >
                <ListGroup.Item key={category.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top">
                    <div className="ms-2 me-auto">
                        <div className="fw-bold">{category.Name}</div>
                        <ul>
                                {category?.Topics.map(topic =>
                            <li>
                                        <button className="btn btn-link" onClick={() => onTopicClick(topic.Id)}>{topic.Name}</button>
                                        </li>
                                )}
                        </ul>
                    </div>
                    <Badge bg="info" pill>
                        Posts: {Math.floor(Math.random() * 99)}
                    </Badge>   
                    </ListGroup.Item>
                    {authContext.user != null &&
                        <button className="btn btn-link" onClick={() => { setActiveCategory(category.Id); setCollapsedTopicModal(false); }}>Create new Topic</button>
                    }
                </div>
            )}
        </div>
    );
}