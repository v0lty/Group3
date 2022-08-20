import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import moment from "moment"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendar } from '@fortawesome/free-solid-svg-icons'

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
        return str.length > 25 ? str.substring(0, 23) + ".." : str;
    }

    return (
        <div className="bg-white shadow">
            <div className="px-2">
                <h6 style={{ color: "#1c4966" }}>NEXT EVENTS</h6>
            </div>
            {events?.Subjects?.map((subject, subjectIndex) => (
                <div key={subjectIndex} className="sidebar-item d-flex align-items-start border-0 border-top pt-2" onClick={() => onSubjectClick(subject.Id)}>
                    <div className="px-2">
                        <FontAwesomeIcon icon={faCalendar} />
                    </div>                                       
                    <div className="row pb-2">
                        <span className="fw-bold">{subject.Name}</span>
                        <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(subject.FirstOrDefaultPost.Text) }} />
                    </div>
                    <div className="px-2">
                        <Badge bg="info" pill>
                            <span>{moment(subject?.FirstOrDefaultPost?.EventDate).fromNow()}</span>
                        </Badge>      
                    </div>
                </div>
            ))}        
        </div>
    );
}