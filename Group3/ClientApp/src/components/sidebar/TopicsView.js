import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import Button from 'react-bootstrap/Button';
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function TopicsView() {
    const authContext = useContext(AuthContext);
    const [topics, setTopics] = useState([]);
    const history = useHistory();

    const updateTopics = async () => {
        API.getHotTopics().then((topics) => {            
            setTopics(topics);
        });
    }

    function routeChange(path) {
        history.push(path);
    }

    useEffect(() => {
        updateTopics();
    }, [])

    const onTopicClick = (id) => {
        routeChange('/topic/' + id);
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 shadow mb-3">
            <div className="p-3">
                <h5>Hot Topics</h5>
            </div>
            <ListGroup as="ol" >                
                {topics.map(topic =>
                    <ListGroup.Item key={topic.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top" onClick={() => onTopicClick(topic.Id)}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{topic.Name}</div>
                            {topic.Description != null ? topic.Description : "Description.."}
                        </div>
                        <Badge bg="danger" pill>
                            { Math.floor(Math.random() * 90) }
                        </Badge>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}