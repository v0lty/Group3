import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useParams } from 'react-router';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

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
            <div className="p-3">
                <h5>{topic?.Category?.Name + ' > ' + topic?.Name}</h5>
            </div>
            <ListGroup as="ol" >
                {topic?.Posts?.map(post =>
                    <ListGroup.Item key={post.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top" onClick={() => console.log('Click')}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{post.Text}</div>
                            {post.Time} - {post.User.Name}
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