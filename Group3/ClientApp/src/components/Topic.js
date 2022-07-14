import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useParams } from 'react-router';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export default function Topic() {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const [topic, setTopic] = useState(null);

    const updateTopic = async () => {
        API.getTopicById({
            topicId: id,
        }).then((topic) => {
            setTopic(topic);
        });
    }

    useEffect(() => {
        updateTopic();
    }, [id])

    return (
        <div>
            <p>{topic?.Name}:</p>
            {
                topic?.Posts?.map(post =>
                    <div key={post?.Id}>
                        <a>{post?.Text}</a>
                        <br />
                    </div>
                )
            }
        </div>
    );
}