import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useParams } from 'react-router';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export default function Category() {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const [category, setCategory] = useState(null);

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

    return (
        <div>
            <p>{category?.Name}:</p>
            <ul className="navbar-nav flex-grow">
                {
                    category?.Topics?.map(topic =>
                        <NavItem key={topic?.Id}>
                            <NavLink tag={Link} to={"/topic/" + topic?.Id}>{topic?.Name}</NavLink>
                        </NavItem>
                    )
                }
            </ul>
        </div>
    );
}