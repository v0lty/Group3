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
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faAdd } from '@fortawesome/free-solid-svg-icons'
import UserGroup from '../UserGroup';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';

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

    const onDeleteCategory = (category) => {
        event.preventDefault();
        if (confirm(`Are you sure that you want to delete '${category.Name}' with all its content?`)) {
            API.deleteCategory({
                categoryId: category.Id,
            }).then(() => {
                updateCategories();
            });
        }
    }

    return (
        <div className="Main">
            <Category category={category} onUpdate={updateCategory} onDelete={onDeleteCategory} />
        </div>
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
        <div className="">
            <div className="d-flex justify-content-between">
                {/*CATEGORY NAME*/}
                <div>
                    <h5 className="fw-bold">{props?.category?.Name}</h5>
                </div>

            </div>
            <ListGroup as="ol" className="pb-2">
                {/*TOPICS*/}
                {props?.category?.Topics.map((topic, topicIndex) =>
                    <ListGroup.Item key={topicIndex} as="li" className="list-item d-flex justify-content-between align-items-start border-0 bg-gray m-1 mx-3" onClick={() => onTopicClick(topic.Id)}>
                        <div className="me-auto" >
                            {/*TOPIC NAME*/}
                            <b className="text-primary">{topic.Name}</b>
                            {/*TOPIC DESCRIPTION*/}
                            <div dangerouslySetInnerHTML={{ __html: topic.Description != null ? topic.Description : "No description" }} />
                        </div>                        
                        <div className="row p-0 m-0">
                            {/*SUBJECTS COUNT*/}
                            <Badge bg="dark" className="mb-1" pill>
                                Subjects: {topic.SubjectsCount}
                            </Badge>
                            {/*DELETE TOPIC*/}
                            <div className="text-end">
                                {authContext?.user != null && authContext?.user?.HasAuthority &&
                                    <OverlayTrigger placement="top" overlay={<Tooltip>Delete Topic</Tooltip>}>
                                        <button className="btn btn-link p-0 m-0 text-danger" onClick={() => onTopicDelete(topic)}>
                                            <FontAwesomeIcon icon={faTrash} />
                                        </button>
                                    </OverlayTrigger>
                                }
                            </div>
                        </div>
                    </ListGroup.Item>
                )}

                <div className="d-flex justify-content-between align-items-start">  
                    <div className="text-start">
                        {/*CREATE NEW TOPIC BUTTON*/}
                        {authContext?.user != null && authContext?.user?.HasAuthority &&
                            <OverlayTrigger placement="top" overlay={<Tooltip>Create Topic</Tooltip>}>
                                <button className="btn btn-link text-success pe-0" onClick={onTopicCreate}>
                                    <FontAwesomeIcon icon={faAdd} />
                                </button>
                            </OverlayTrigger>
                        }
                        {/*DELETE CATEGORY BUTTON*/}
                        {authContext?.user != null && authContext?.user?.HasAuthority &&
                            <OverlayTrigger placement="top" overlay={<Tooltip>Delete Category</Tooltip>}>
                                <button className="btn btn-link text-danger pe-0" onClick={props?.onDelete}>
                                    <FontAwesomeIcon icon={faTrash} />
                                </button>
                            </OverlayTrigger>
                        }
                    </div>
                    {props?.category?.UserGroup != null &&
                        /*USERGROUP*/
                        <div className="float-end pe-3 pt-2 ">
                            <UserGroup users={props?.category?.UserGroup?.UserGroupEnlistments?.map(x => (x.User))} />
                        </div>
                    }
                </div>
            </ListGroup>

           {/*CREATE TOPIC MODAL*/}
            <Modal show={modalVisible} onHide={() => setModalVisible(false)} backdrop="static" centered>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Create Topic in '{props?.category?.Name}'
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