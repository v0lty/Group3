import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
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
        return str.length > 33 ? str.substring(0, 31) + ".." : str;
    }

    if (events == null || events.length == 0) {
        return (<div />);
    }
    else {
        return (
            <div className="bg-white shadow">
                <div className="p-2 text-center">
                    <h6>NEXT EVENTS</h6>
                </div>
                {events?.Subjects?.map((subject, subjectIndex) => (
                    <div key={subjectIndex} className="sidebar-item d-flex border-0 border-top pt-2" onClick={() => onSubjectClick(subject.Id)}>
                        <div className="col-2" style={{ width: 30 }}>
                            <div className="ps-2"  >
                                <FontAwesomeIcon icon={faCalendar} />
                            </div>
                        </div>
                        <div className="col pe-2">
                            <div className="d-flex justify-content-between align-items-start">
                                <span className="fw-bold">{subject.Name}</span>
                                <div className="badge rounded-pill bg-events-pill" >
                                    <span>{moment(subject?.FirstOrDefaultPost?.EventDate).fromNow()}</span>
                                </div>
                            </div>
                            <div className="row">
                                <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(subject.FirstOrDefaultPost.Text) }} />
                            </div>

                        </div>
                    </div>
                ))}
            </div>
        );
    }
}