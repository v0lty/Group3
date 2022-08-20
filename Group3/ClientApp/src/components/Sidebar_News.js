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

        <div className="bg-white shadow mb-4">
            <div className="px-2">
                <h6 style={{ color: "#1c4966" }}>LATEST NEWS</h6>
            </div>
            {news?.Topics?.filter(x => x.Name != "Events")?.map(topic => (
                topic.Subjects?.map((subject, subjectIndex) => (
                    <div key={subjectIndex} className="sidebar-item d-flex align-items-start border-0 border-top pt-2" onClick={() => onSubjectClick(subject.Id)}>
                        <div className="px-2">
                            <FontAwesomeIcon icon={faNewspaper} />
                        </div>                                       
                        <div className="row pb-2">
                            <span className="fw-bold">{topic.Name}</span>
                            <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(subject.Name) }} />
                        </div>
                        <div className="px-2">
                            <Badge bg="info" pill>
                                {moment(subject?.FirstOrDefaultPost?.Time).fromNow()}
                            </Badge>
                        </div>
                    </div>
                ))
            ))}         
        </div>
    );
}