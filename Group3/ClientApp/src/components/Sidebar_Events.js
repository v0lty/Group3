﻿import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import moment from "moment"


export default function Sidebar_Events() {
    const authContext = useContext(AuthContext);
    const [events, setEvents] = useState([]);
    const history = useHistory();

    const updateEvents = async () => {
        API.getNextEvents().then((events) => {
            setEvents(events);
        });
    }

    useEffect(() => {
        updateEvents();
    }, [])

    const onSubjectClick = (id) => {
        history.push('/subject/' + id);
    }

    const truncate = (str) => {
        return str.length > 23 ? str.substring(0, 20) + "..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <h6 style={{ color: "#1c4966" }}>NEXT EVENTS</h6>
            <ListGroup as="ul" className="shadow">
                {events?.Subjects?.map(subject => (
                    <ListGroup.Item key={subject.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onSubjectClick(subject.Id)}>
                        <div className="col-3" style={{ width: 45 }}>
                            <img className="profile-image-extra-small" src={`../Pictures/_NewsTopic/event.jpg`}></img>
                        </div>
                        <div className="col">
                            <div className="row">
                                <div className="col">
                                    <span className="fw-bold">Events</span>
                                </div>

                                    <div className="col p-0 pe-1 d-flex justify-content-end">
                                        <Badge bg="success" pill>
                                            <span>{moment(subject?.FirstOrDefaultPost?.EventDate).fromNow()}</span>
                                        </Badge>
                                    </div>
                            </div>
                            <div className="btn btn-link p-0 m-0">
                                <div className="ms-2 me-auto">
                                    <a className="sidebar-news">{truncate(subject.Name)}</a>
                                </div>
                            </div>
                        </div>
                    </ListGroup.Item>
                ))}
            </ListGroup>
        </div>
    );
}