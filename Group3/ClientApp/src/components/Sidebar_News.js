import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
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

    const onSubjectClick = (id) => {
        history.push('/subject/' + id);
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <h6 style={{ color: "#1c4966" }}>LATEST NEWS</h6>
            <ListGroup as="ul" className="shadow">
                {news?.Topics?.map(topic => (
                    topic.Subjects?.map(subject => (
                        <ListGroup.Item key={subject.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onSubjectClick(subject.Id)}>
                            <div className="ms-2 me-auto">
                                <div className="fw-bold">{subject.Name}</div>
                            </div>
                        </ListGroup.Item>
                    ))
                ))}
            </ListGroup>
        </div>
    );
}