import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import moment from "moment"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faNewspaper } from '@fortawesome/free-solid-svg-icons'

export default function Sidebar_LatestNews() {
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

    if (news == null || news.length == 0) {
        return (<div />);
    }
    else {
        return (
            <div className="bg-white shadow mb-4">
                <div className="p-2 text-center">
                    <h6 style={{ color: "#1c4966" }}>LATEST NEWS</h6>
                </div>
                {news?.Topics?.filter(x => x.Name != "Events")?.map(topic => (
                    topic.Subjects?.map((subject, subjectIndex) => (
                        <div key={subjectIndex} className="sidebar-item d-flex border-0 border-top pt-2" onClick={() => onSubjectClick(subject.Id)}>
                            <div className="col-2" style={{ width: 30 }}>
                                <div className="ps-2"  >
                                    <FontAwesomeIcon icon={faNewspaper} />
                                </div>
                            </div>
                            <div className="col pe-2">
                                <div className="d-flex justify-content-between align-items-start">
                                    <span className="fw-bold">{topic.Name}</span>
                                    <div className="badge rounded-pill bg-news-pill" >
                                        {moment(subject?.FirstOrDefaultPost?.Time).fromNow()}
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(subject.Name) }} />
                                </div>
                            </div>
                        </div>
                    ))
                ))}
            </div>
        );
    }
}