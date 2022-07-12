import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import Button from 'react-bootstrap/Button';
import { useHistory } from "react-router-dom";

export default function Template() {
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

    return (
        <div>
            {
                categories.map(category =>
                    <div key={category?.Id }>
                        <Button onClick={() => onCategoryClick(category.Id) } variant="link">{category.Name}</Button>
                    </div>
                )
            }
        </div>
    );
}