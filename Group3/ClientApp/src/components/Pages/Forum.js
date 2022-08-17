import React, { useState, useContext, useEffect } from 'react';
import API from "../API";
import { AuthContext } from "../UserAuthentication";
import ListGroup from 'react-bootstrap/ListGroup';
import Category from './Category'

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
                        {/*NOTE: view category if UserGroup is null OR if UserGroup contains User.Id
                                 .map(x => (x.User.Id) selects User.Id into array, remove it to access full User.*/}
                        {(category?.UserGroup == null
                       || category?.UserGroup?.UserGroupEnlistments?.map(x => (x.User.Id)).includes(authContext?.user?.Id)) &&
                            <Category category={category} onUpdate={updateCategories} />
                        }
                    </ListGroup.Item>
                ))}
            </ListGroup>
        </div>
    );
}