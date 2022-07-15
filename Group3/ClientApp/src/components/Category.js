import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useParams } from 'react-router';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function Category() {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const [category, setCategory] = useState(null);
    const history = useHistory();

    const updateCategories = async () => {
        API.getCategoryById({
            categoryId: id,
        }).then((category) => {
            setCategory(category);
        });
    }

    useEffect(() => {
        updateCategories();
    }, [id])

    function routeChange(path) {
        history.push(path);
    }

    return (
        <div>
            <div className="p-3">
                <h5>{category?.Name}</h5>
            </div>
            <ListGroup as="ol" >
                {category?.Topics?.map(topic =>
                    <ListGroup.Item key={topic.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top" onClick={() => routeChange('/topic/' + topic.Id)}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{topic.Name}</div>
                            {topic.Description}
                        </div>
                        <Badge bg="dark" pill>
                            {Math.floor(Math.random() * 90)}
                        </Badge>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}