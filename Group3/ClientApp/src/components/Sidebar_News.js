import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import moment from "moment"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faNewspaper } from '@fortawesome/free-solid-svg-icons'

export default function Sidebar_News() {
    const authContext = useContext(AuthContext);
    const [news, setNews] = useState([]);
    const history = useHistory();

    const updateNews = async () => {
        API.getLatestNews().then((news) => {
            setNews(news);
        });
    }

    useEffect(() => { 
        updateNews();
    }, [])

    const onSubjectClick = (id) => {
        history.push('/subject/' + id);
    }

    const truncate = (str) => {
        return str.length > 23 ? str.substring(0, 20) + "..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-4">
            <h6 style={{ color: "#1c4966" }}>LATEST NEWS</h6>
            <ListGroup as="ul" className="shadow">
                {news?.Topics?.filter(x => x.Name != "Events")?.map(topic => (
                    topic.Subjects?.map(subject => (
                        <ListGroup.Item key={subject.Id} as="li" className="sidebar-item d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onSubjectClick(subject.Id)}>
                            <div className="col-3" style={{ width: 30 }}>
                                <FontAwesomeIcon icon={faNewspaper} />
                            </div>
                            <div className="col">
                                <div className="row">
                                    <div className="col">
                                        <b>{topic.Name}</b>
                                    </div>                             
                                    <div className="col p-0 pe-1 d-flex justify-content-end">
                                        <Badge bg="info" pill>
                                        <span>{moment(subject?.FirstOrDefaultPost?.Time).fromNow()}</span>
                                        </Badge>
                                    </div>                              
                                </div>
                                <div className="p-0 m-0">
                                    <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(subject.Name) }} />
                                </div>
                            </div>
                        </ListGroup.Item>
                    ))
                ))}
            </ListGroup>
        </div>
    );
}