import React, { useState, useContext, useEffect } from 'react';
import API from "../API";
import { AuthContext } from "../UserAuthentication";
import ListGroup from 'react-bootstrap/ListGroup';
import Category from './Category'
import Form from 'react-bootstrap/Form'
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Modal from 'react-bootstrap/Modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faAdd} from '@fortawesome/free-solid-svg-icons'

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);
    const [showCreateCategoryModal, setShowCreateCategoryModal] = useState(false);

    const updateCategories = async () => {
        API.getAllCategories().then((categories) => {
            setCategories(categories);
        });
    }

    useEffect(() => {
        updateCategories();
    }, [])

    const onCreateCategorySubmit = (event) => {
        event.preventDefault();

        API.createCategory({
            name: event.target.elements['categoryNameInput'].value,
            description: event.target.elements['categoryDescriptionInput'].value,
        }).then((category) => {            
            setShowCreateCategoryModal(false);
            updateCategories();
        });
    }

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
        <div>            
            <div className="context bg-white shadow">
                <h3>Forum</h3>
                <ListGroup as="ol">
                    {categories.map((category, categoryIndex) => category.Name != "News" && (
                        <ListGroup.Item key={categoryIndex} as="li" className="border-0">
                            {(category?.UserGroup == null
                                || (authContext?.user != null &&
                                    category?.UserGroup?.UserGroupEnlistments?.map(x => (x.User.Id)).includes(authContext?.user?.Id))) &&
                                <div className="shadow p-3 mb-3">                
                                    <Category category={category} onUpdate={updateCategories} onDelete={() => onDeleteCategory(category) } />
                                </div>
                            }              
                        </ListGroup.Item>
                    ))}
                </ListGroup>
                <div className="row">
                    <div className="text-end">
                        {authContext?.user != null && authContext?.user?.HasAuthority &&
                            <button className="btn btn-link text-success py-0" onClick={() => setShowCreateCategoryModal(true)}>
                                <FontAwesomeIcon icon={faAdd} />
                            </button>
                        }
                    </div>
                </div>

                <Modal show={showCreateCategoryModal} onHide={() => setShowCreateCategoryModal(false)} backdrop="static">
                    <Modal.Header closeButton>
                        <Modal.Title>Create Category</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={onCreateCategorySubmit}>
                            <input type="submit" id="submitInput" className="d-none" />
                            <FloatingLabel label="Name" className="mb-3">
                                <Form.Control type="text" id="categoryNameInput" />
                            </FloatingLabel>
                            <FloatingLabel label="Description" className="mb-3">
                                <Form.Control type="text" id="categoryDescriptionInput" />
                            </FloatingLabel>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
                    </Modal.Footer>
                </Modal>
            </div>
        </div>
    );
}