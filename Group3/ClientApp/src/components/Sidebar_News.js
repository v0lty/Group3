import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function Sidebar_News() {
    const authContext = useContext(AuthContext);
    const [news, setNews] = useState([]);
    const history = useHistory();

    const updateNews = async () => {
        API.getNews().then((news) => {
            setNews(news);
        });
    }

    useEffect(() => { 
        updateNews();
    }, [])

    const onTopicClick = (id) => {
        history.push('/topic/' + id);
    }
    const truncate = (str) => {
        return str.length > 25 ? str.substring(0, 23) + " ..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <h5>Latest News</h5>
            <ListGroup as="ul" className="shadow">
                {news?.Topics?.map(topic =>
                    <ListGroup.Item key={topic.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onTopicClick(topic.Id)}>
                        <div className="ms-2 me-auto">
                            <div className="fw-bold">{topic.Name}</div>
                            {topic.Description != null ? truncate(topic.Description) : "Description"}
                        </div>
                        <Badge bg="dark" pill>
                            Subjects: { topic.SubjectsCount }
                        </Badge>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}