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
import UserSelectModal from '../UserSelectModal';
import UserGroup from '../UserGroup';

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);
    const [showCreateCategoryModal, setShowCreateCategoryModal] = useState(false);
    const [userGroup, setUserGroup] = useState(false);
    const [userGroupDefaultValue, setUserGroupDefaultValue] = useState(false);
    const [peopleSelectModalVisible, setPeopleSelectModalVisible] = useState(false);

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

        if (userGroupDefaultValue && userGroup == null) {
            alert("Select atleast one user or deselect the UserGroup option!");
            return;
        }

        API.createCategory({
            name: event.target.elements['categoryNameInput'].value,
            description: event.target.elements['categoryDescriptionInput'].value,
            users: userGroup?.map(x => (x.Id)).join(","),
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

    const onUsergroupSelectSubmit = async (users) => {
        if (users == null || users.length == 0) {
            alert("Select atleast one user!");
            return;
        }

        setUserGroup(users);
        setPeopleSelectModalVisible(!peopleSelectModalVisible);
    }

    const onUserGroupSwitchChanged = async (event) => {
        setUserGroup(null);
        setUserGroupDefaultValue(event.target.checked);
        setPeopleSelectModalVisible(event.target.checked);
    }

    const onCreateCategoryReset = async () => {
        setShowCreateCategoryModal(false);
        setPeopleSelectModalVisible(false);
        setUserGroupDefaultValue(false);
        setUserGroup(null);
    }

    const onSelectPeopleReset = async () => {        
        setPeopleSelectModalVisible(false);
        setUserGroupDefaultValue(false);
        setUserGroup(null);
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
                                    {/*CATEGORY*/}
                                    <Category category={category} onUpdate={updateCategories} onDelete={() => onDeleteCategory(category) } />
                                </div>
                            }              
                        </ListGroup.Item>
                    ))}
                </ListGroup>
                <div className="row">
                    <div className="text-end">
                        {authContext?.user != null && authContext?.user?.HasAuthority &&
                            /*CREATE CATEGORY BUTTON*/
                            <button className="btn btn-link text-success py-0" onClick={() => setShowCreateCategoryModal(true)}>
                                <FontAwesomeIcon icon={faAdd} />
                            </button>
                        }
                    </div>
                </div>

                {/*CREATE CATEGORY MODAL*/}
                <Modal show={showCreateCategoryModal} onHide={onCreateCategoryReset} backdrop="static" centered>
                    <Modal.Header closeButton>
                        <Modal.Title>Create Category</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={onCreateCategorySubmit}>
                            <input type="submit" id="createCategorySubmitInput" className="d-none" />
                            <FloatingLabel label="Name" className="mb-3">
                                <Form.Control type="text" id="categoryNameInput" required />
                            </FloatingLabel>
                            <FloatingLabel label="Description" className="mb-3">
                                <Form.Control type="text" id="categoryDescriptionInput" required />
                            </FloatingLabel>
                            <div className="form-check form-switch mb-3">
                                <input className="form-check-input" type="checkbox" defaultChecked={userGroupDefaultValue} onChange={onUserGroupSwitchChanged} />
                                <label className="form-check-label">Usergroup</label>
                            </div>
                            {userGroupDefaultValue && userGroup != null && (
                                <UserGroup users={userGroup}/>
                            )}
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <label htmlFor="createCategorySubmitInput" className="btn btn-primary">Submit</label>
                    </Modal.Footer>
                </Modal>

                {/*USER SELECT MODAL*/}
                <UserSelectModal
                    title="Select People"
                    onSubmit={onUsergroupSelectSubmit}
                    visible={peopleSelectModalVisible}
                    onHide={onSelectPeopleReset}
                />
            </div>
        </div>
    );
}