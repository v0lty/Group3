import React, { useContext, useState, useEffect } from 'react';
import AuthContext from "../UserAuthentication";
import API from "../API";
import ListGroup from 'react-bootstrap/ListGroup';
import Badge from 'react-bootstrap/Badge';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";

// URL PATH -> LOCALHOST/CATEGORY/{ID}
export const CategoryPath = () => {
    const { id } = useParams();
    const history = useHistory();
    const [category, setCategory] = useState(null);

    const updateCategory = async () => {
        API.getCategoryById({
            categoryId: id,
        }).then((category) => {
            setCategory(category);
        });
    }

    useEffect(() => {
        updateCategory();
    }, [id])

    return (
        <Category category={category} onUpdate={updateCategory} />
    );
}

// PROPS
export const Category = props => {
    const authContext = useContext(AuthContext);
    const [modalVisible, setModalVisible] = useState(false);
    const history = useHistory();

    const onTopicClick = (id) => {
        history.push('/topic/' + id);
    }

    const onTopicDelete = (topic) => {
        if (topic.SubjectsCount === 0 ||
            window.confirm(`WARNING!\n\nThis will delete '${topic.Name}' including Subjects and Posts inside it.\nAre you REALLY sure?`)) {
            API.deleteTopic({
                topicId: topic.Id,
            }).then((category) => {
                props?.onUpdate();
            });
        }
    }

    const onTopicCreate = () => {
        setModalVisible(true);
    }

    const onTopicSubmit = async (event) => {
        event.preventDefault();

        if (event.target.elements['nameInput'].value == "") {
            alert("Empty");
            return;
        }
        API.createTopic({
            name: event.target.elements['nameInput'].value,
            description: event.target.elements['descriptionInput'].value,
            categoryId: props?.category?.Id
        }).then((user) => {
            setModalVisible(false);
            props?.onUpdate();
        });
    }

    return (
        <div>
            {/*CATEGORY NAME*/}
            <h5 className="fw-bold">{props?.category?.Name}</h5>
            {/*NOTE: For testing only 
                     .map(x => (x.User.Name) selects User.Name into array, remove it to access full User.*/}
            {props?.category?.UserGroup != null &&
                <p className="text-muted">Memebers: {props?.category?.UserGroup?.UserGroupEnlistments?.map(x => (x.User.Name)).join(', ')}</p>
                
            }            
            <ListGroup as="ol" className="pb-2">
                {/*TOPICS*/}
                {props?.category?.Topics.map((topic, topicIndex) =>
                    <ListGroup.Item key={topicIndex} as="li" className="d-flex justify-content-between align-items-start border-0 bg-gray m-1 mx-3">
                        <div className="me-auto">
                            {/*TOPIC NAME*/}
                            <div className=""><button className="btn btn-link fw-bold m-0 p-0" onClick={() => onTopicClick(topic.Id)}>{topic.Name}</button></div>
                            {/*TOPIC DESCRIPTION*/}
                            <div dangerouslySetInnerHTML={{ __html: topic.Description != null ? topic.Description : "No description" }} />
                        </div>                        
                        <div className="row p-0 m-0">
                            {/*SUBJECTS COUNT*/}
                            <Badge bg="dark" className="mb-1" pill>
                                Subjects: {topic.SubjectsCount}
                            </Badge>
                            {/*DELETE*/}
                            {authContext?.user != null && authContext?.user?.HasAuthority &&
                                <button className="btn btn-link p-0 m-0 text-danger" onClick={() => onTopicDelete(topic)}>Delete Topic</button>
                            }
                        </div>
                    </ListGroup.Item>
                )}
            </ListGroup>

            {/*CREATE NEW TOPIC BUTTON*/}
            { authContext?.user != null && authContext?.user?.HasAuthority &&
                <button className="btn btn-link text-success m-0 p-0" onClick={onTopicCreate}>Create a new Topic in {props?.category?.Name}</button>
            }

           {/*CREATE TOPIC MODAL*/}
            <Modal show={modalVisible} onHide={() => setModalVisible(false)} backdrop={false}>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Create Topic
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={onTopicSubmit}>
                        <input type="submit" id="submitInput" className="d-none" />
                        <Form.Group className="m-2">
                            <FloatingLabel label="Name" className="mb-3">
                                <Form.Control type="text" placeholder="Name" id="nameInput" required />
                            </FloatingLabel>
                        </Form.Group>
                        <Form.Group className="m-2">
                            <FloatingLabel label="Description" className="mb-3">
                                <Form.Control type="text" placeholder="Description" id="descriptionInput" required />
                            </FloatingLabel>
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