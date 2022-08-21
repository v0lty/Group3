import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import InputModal from '../InputModal';
import ListGroup from 'react-bootstrap/ListGroup';
import Badge from 'react-bootstrap/Badge';
import { useHistory } from "react-router-dom";
import { useParams } from 'react-router';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faAdd } from '@fortawesome/free-solid-svg-icons'

// URL PATH -> LOCALHOST/TOPIC/{ID}
export const TopicPath = () => {
    const { id } = useParams();
    const history = useHistory();
    const [topic, setTopic] = useState(null);

    const updateTopic = async () => {     
        API.getTopicById({
            topicId: id,
        }).then((topic) => {
            setTopic(topic);           
        });
    }

    useEffect(() => {
        updateTopic();
    }, [id])

    return (
        <div className="context bg-white shadow">
            <Topic topic={topic} onUpdate={updateTopic} />
        </div>
    );
}

// PROPS
export const Topic = props => {
    const authContext = useContext(AuthContext);
    const [modalVisible, setModalVisible] = useState(false);
    const history = useHistory();

    const onSubjectClick = (id) => {
        history.push('/subject/' + id);
    }

    const onSubjectDelete = (subject) => {
        if (subject.PostsCount === 0 ||
            window.confirm(`WARNING!\n\nThis will delete '${subject.Name}' including Posts inside it.\nAre you REALLY sure?`)) {
            API.deleteSubject({
                subjectId: subject.Id,
            }).then(() => {
                props?.onUpdate();
            });
        }
    }

    const onSubjectSubmit = async (event, title, text) => {
        if (title == "") {
            alert("Subject can't be empty!");
            return;
        }
        API.createSubject({
            name: title,
            topicId: props?.topic?.Id
        }).then((subject) => {
            API.createPost({
                userId: authContext?.user?.Id,
                subjectId: subject.Id,
                text: text,                
            }).then((post) => {
                setModalVisible(false);
                history.push('/subject/' + subject.Id);
            });
        });
    }

    return (
        <div>         
            <h5 className="m-0 p-0 pb-3">
                <a className="text-decoration-none" href={`/category/${props?.topic?.Category?.Id}`}>{props?.topic?.Category?.Name}</a>
                {" > "}
                <span>{props?.topic?.Name}</span>
            </h5>
            <ListGroup as="ol" className="pb-2">
                {/*SUBJECTS*/}
                {props?.topic?.Subjects?.map((subject, subjectIndex) =>
                    <ListGroup.Item key={subjectIndex} as="li" className="list-item d-flex justify-content-between align-items-start border-0 bg-gray m-1 mx-3" onClick={() => onSubjectClick(subject.Id)}>
                        <div className="me-auto">
                            {/*SUBJECT NAME*/}
                            <b>{subject.Name}</b>
                        </div>
                        <div className="row p-0 m-0">
                            {/*Post COUNT*/}
                            <Badge bg="dark" className="mb-1" pill>
                                Posts: {subject.PostsCount}
                            </Badge>
                            {/*DELETE*/}
                            <div className="text-end">
                                {authContext?.user != null && authContext?.user?.HasAuthority &&
                                    <button className="btn btn-link p-0 m-0 text-danger" onClick={() => onSubjectDelete(subject)}>
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                }
                            </div>
                        </div>
                    </ListGroup.Item>
                )}
            </ListGroup>
            <div className="border-top">
                <InputModal
                    title="Create Subject"
                    useTitle={true}
                    inputTitle="Title"
                    input=""
                    onSubmit={onSubjectSubmit}
                    visible={modalVisible}
                    onHide={() => { setModalVisible(!modalVisible); }}
                />
                {authContext.user != null && 
                    <button className="btn btn-link my-2 text-success" onClick={() => { setModalVisible(!modalVisible); }}>
                        <FontAwesomeIcon icon={faAdd} />
                    </button>
                }
            </div>
        </div>
    );
}

export default Topic;