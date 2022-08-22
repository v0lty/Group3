import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import { useParams } from 'react-router';
import Post from './Post';
import InputModal from '../InputModal';
import moment from "moment";
import { useHistory } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faReply } from '@fortawesome/free-solid-svg-icons'
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';

// URL PATH -> LOCALHOST/SUBJECT/{ID}
export const SubjectPath = () => {
    const { id } = useParams();
    const history = useHistory();
    const [subject, setSubject] = useState(null);

    const updateSubject= async () => {
        API.getSubjectById({
            subjectId: id,
        }).then((subject) => {
            setSubject(subject);
        });
    }

    useEffect(() => {
        updateSubject();
    }, [id])

    return (
        <div className="context bg-white shadow">
            <Subject subject={subject} onUpdate={updateSubject} />
        </div>
    );
}

// PROPS
export const Subject = props => {
    const authContext = useContext(AuthContext);
    const [input, setInput] = useState("");
    const [modalVisible, setModalVisible] = useState(false);

    const onPostQuote = (post) => {
        setInput(
            `<blockquote>
                <span>
                    Quote by<a href="/post/${post.Id}">
                        ${post.Author.Name} @ 
                        ${moment(post.Time).utc().format('YYYY/MM/DD HH:mm')}
                    </a><br />
                    ${post.Text}
                </span>                                     
             </blockquote>`
        );
        setModalVisible(!modalVisible)
    }

    const onPostSubmit = (event, title, text) => {
        API.createPost({
            text: text,
            userId: authContext?.user?.Id,
            subjectId: props?.subject?.Id
        }).then(() => {
            setInput("");
            props?.onUpdate();
            setModalVisible(!modalVisible)
        });
    }

    return (
        <div className="">
            <h5 className="m-0 p-0 pb-3">
                {/*PATH*/}
                <a className="text-decoration-none" href={`/category/${props?.subject?.Topic?.Category?.Id}`}>{props?.subject?.Topic?.Category?.Name}</a>
                {" > "}
                <a className="text-decoration-none" href={`/topic/${props?.subject?.Topic?.Id}`}>{props?.subject?.Topic?.Name}</a>
                {" > "}
                <span>{props?.subject?.Name}</span>
            </h5>
            {props?.subject?.Posts?.map((post, postIndex) =>
                /*POST*/
                <Post
                    key={postIndex}
                    post={post}        
                    onUpdate={() => { props?.onUpdate() }}
                    onQuote={onPostQuote}
                />
            )}
            <div className="d-flex justify-content-end">
                {/*REPLY MODAL*/}
                <InputModal                    
                    title={"Reply to '" + props?.subject?.Name + "'"}
                    useTitle={false}
                    input={input}
                    onSubmit={onPostSubmit}
                    visible={modalVisible}
                    onHide={() => { setModalVisible(!modalVisible); }}
                />
                {authContext.user != null &&
                    <OverlayTrigger placement="top" overlay={<Tooltip>Post a message in this thread</Tooltip>}>
                        <button className="btn btn-link my-2 text-dark" onClick={() => { setModalVisible(!modalVisible); }}>                    
                            <FontAwesomeIcon icon={faReply} />
                        </button>   
                    </OverlayTrigger>
                }
            </div>
        </div>
    );
}

export default Subject;