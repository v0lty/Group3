import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import Button from 'react-bootstrap/Button';
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function CategoriesView() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);
    const history = useHistory();

    const updateCategories = async () => {
        API.getAllCategories().then((categories) => {
            setCategories(categories);
        });
    }

    function routeChange(path) {
        history.push(path);
    }

    useEffect(() => { 
        updateCategories();
    }, [])

    const onCategoryClick = (id) => {
        routeChange('/category/' + id);
    }

    var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

    return (
        <div className="d-flex flex-column align-items-stretch border-0 shadow mb-3">
            <div className="p-3">
                <h6 style={{ color: "#1c4966" }}>CATEGORIES</h6>
            </div>
            <ListGroup as="ol" >                
                {categories.map(category =>
                    <ListGroup.Item key={category.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top" onClick={() => onCategoryClick(category.Id)}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{category.Name}</div>
                            {category.Text != null ? category.Text : "Description.."}
                        </div>
                        <Badge bg="info" pill>
                            {days[Math.floor(Math.random() * 6)]}
                        </Badge>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}