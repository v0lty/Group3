import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function Sidebar_Subjects() {
    const authContext = useContext(AuthContext);
    const [subjects, setSubjects] = useState([]);
    const history = useHistory();

    const updateSubjects = async () => {
        API.getHotSubjects().then((subjects) => {
            setSubjects(subjects);
        });
    }

    useEffect(() => {
        updateSubjects();
    }, [])

    const onSubjectClick = (id) => {
        history.push('/subject/' + id);
    }

    const truncate = (str) => {
        return str.length > 18 ? str.substring(0, 15) + " ..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <div>
                <h6 style={{ color: "#1c4966" }}>HOT SUBJECTS&#128293;</h6>
            </div>
            <ListGroup as="ul" className="shadow">
                {subjects?.reverse().map(subject =>
                    <ListGroup.Item key={subject.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow pe-2" onClick={() => onSubjectClick(subject.Id)}>       
                        <div>
                        <span className="btn-link">{truncate(subject.Name)}</span><br />
                            ...
                        </div>
                        <div className="col p-0 d-flex justify-content-end">
                            <Badge bg="danger" pill>
                                Posts: {subject.PostsCount}
                            </Badge>
                        </div>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}