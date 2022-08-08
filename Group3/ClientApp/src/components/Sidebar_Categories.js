import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function Sidebar_Categories() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);
    const history = useHistory();

    const updateCategories = async () => {
        API.getAllCategories().then((categories) => {
            setCategories(categories);
        });
    }

    useEffect(() => { 
        updateCategories();
    }, [])

    const onCategoryClick = (id) => {
        history.push('/category/' + id);
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <h6 style={{ color: "#1c4966" }}>CATEGORIES</h6>
            <ListGroup as="ul" className="shadow">
                {categories.map(category =>
                    <ListGroup.Item key={category.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onCategoryClick(category.Id)}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{category.Name}</div>
                            {category.Text != null ? category.Text : "Description"}
                        </div>
                        <Badge bg="success" pill>
                            Topics: { category.TopicsCount }
                        </Badge>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}