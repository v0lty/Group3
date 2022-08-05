import React, { useState, useContext, useEffect } from 'react';
import API from "../API";
import { AuthContext } from "../UserAuthentication";
import ListGroup from 'react-bootstrap/ListGroup';
import CategoryComponent from './Category'

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [categories, setCategories] = useState([]);

    const updateCategories = async () => {
        API.getAllCategories().then((categories) => {
            setCategories(categories);
        });
    }

    useEffect(() => {
        updateCategories();
    }, [])

    return (
        <div>
            <ListGroup as="ol">
                {categories.map((category, categoryIndex) => category.Name != "News" && (
                    <ListGroup.Item key={categoryIndex} as="li" className="border-0">
                        <CategoryComponent
                            category={category}
                            onUpdate={updateCategories} />
                    </ListGroup.Item>
                ))}
            </ListGroup>
        </div>
    );
}