﻿import React, { useContext, useState, useEffect } from 'react';
import moment from "moment";
import AuthContext from "../UserAuthentication";
import RichTextEditor from 'react-rte';
import API from "../API";
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faAdd, faPencilSquare, faQuoteRight, faFlag, faThumbsUp, faAddressBook, faCommenting, faReply } from '@fortawesome/free-solid-svg-icons'

var oneHour = 60 * 60 * 1000; /* ms is the standard time measurement in js */

// URL
export const PostPath = () => {
    const { id } = useParams();
    const history = useHistory();
    const [post, setPost] = useState(null);

    const updatePost = () => {
        API.getPostById({
            postId: id
        }).then((post) => {
            setPost(post);
        });
    };

    useEffect(() => {     
        updatePost();
    }, [id])

    return (
        <div className="context bg-white">
            <h5 className="m-0 p-0 pb-3">
                <a className="text-decoration-none" href={`/category/${post?.Subject?.Topic?.Category?.Id}`}>{post?.Subject?.Topic?.Category?.Name}</a>
                {" > "}
                <a className="text-decoration-none" href={`/topic/${post?.Subject?.Topic?.Id}`}>{post?.Subject?.Topic?.Name}</a>
            </h5>
            <Post post={post} onUpdate={updatePost} onEdit={updatePost} onDelete={() => { history.push('/'); }} />
        </div>
    );
}

// PROPS
export const Post = props => {
    const authContext = useContext(AuthContext);
    const [editMode, setEditMode] = useState(false);
    const [editPost, setEditPost] = useState(null);
    const [value, setValue] = useState(RichTextEditor.createEmptyValue());
    const [show, setShow] = useState(false);
    const history = useHistory();

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
   
    const onEditClick = (post) => {
        setValue(RichTextEditor.createValueFromString(post.Text, 'html'));
        setEditPost(post);
        setEditMode(!editMode);
    }

    const onChange = async (value) => {
        setValue(value);
    };

    const onSave = () => {
        const text = value.toString('html')
            + `<span><i>Edited by ${authContext?.user?.Name}@ ${moment(moment.now()).format('YYYY/MM/DD HH:mm:ss')}</i></span><br/>`;

        API.editPost({
            postId: editPost.Id,
            postText: text
        }).then(() => {
            setValue(RichTextEditor.createEmptyValue());
            setEditMode(!editMode);
            props?.onUpdate();
        });
    };

    const onDelete = (id) => {
        API.deletePost({
            postId: id
        }).then(() => {
            props.onUpdate()
        });
    }

    const onReport = (id) => {
        API.reportPost({
            postId: id,
        }).then((num) => {
            alert("Post was reported, thank you!");
        });
    }

    const onVote = (id) => {
        API.upVotePost({
            postId: id
        }).then(() => {
            props.onUpdate();
        });
    }

    return (
        <div className="mb-3 pb-3 bg-white border-bottom">
            <div className="row p-2">
                <div>
                    {/*TIME*/}
                    <span><b>{moment(props?.post?.Time).fromNow()}</b></span>
                    {/*VOTE*/}
                    <button className="btn border-0 float-end p-0 px-2" onClick={() => onVote(props?.post?.Id)}>
                        <span className="fw-bold">{props?.post?.Votes} </span> 
                        <FontAwesomeIcon className="text-warning" icon={faThumbsUp} />
                    </button>
                </div>
            </div>
            <div className="row">
                <div className="col-1 mb-4" style={{ minWidth: 175 }}>
                    {/*USER*/}
                    <div>
                        <div className="row m-0">
                            <img className="profile-picture pb-2" src={`../Pictures/${props?.post?.Aurthor.ProfilePicture?.Path}`}></img>
                        </div>
                        <div className="row m-0">
                            {authContext?.user?.Id != props?.post?.Aurthor?.Id ? (
                                <h5>{props?.post?.Aurthor?.Name}</h5>
                            ) : (
                                <h5>You</h5>
                            )}
                            <span className="text-muted">
                                <b className="text-info">{props?.post?.Aurthor?.RoleString}</b><br />
                                <b>{moment().diff(props?.post?.Aurthor?.Birthdate, 'years')}</b> years old<br />
                                from <b>{props?.post?.Aurthor?.Location}</b><br />                               
                                with <b className="text-danger">{props?.post?.Aurthor?.PostsCount}</b> posts.<br />
                                <br />
                                <div className="d-flex align-items-start">
                                    <button className="btn btn-link p-0 m-0 pe-3" onClick={() => history.push(`/user/${props?.post?.Aurthor?.Id}`)}>
                                        <FontAwesomeIcon icon={faAddressBook} />                                        
                                    </button><br />
                                    {authContext?.user?.Id != props?.post?.Aurthor?.Id && (
                                        <button className="btn btn-link p-0 m-0 pe-3" onClick={() => history.push(`/messages/${props?.post?.Aurthor?.Id}`)}>
                                            <FontAwesomeIcon icon={faCommenting} />
                                        </button>
                                    )}
                                </div>
                            </span>
                        </div>
                    </div>
                </div>
                <div className="col pe-4 px-2" style={{ minWidth: 250 },{ minHeight: 100 }}>
                    <div className="h-100 w-100 p-3 bubble">
                        {editMode == true ? (
                            /*EDIT*/
                            <div>
                                <RichTextEditor className="new-post-editor" value={value} onChange={onChange} />
                                <button className="btn btn-secondary my-2" onClick={onSave}>Save</button>
                            </div>
                        ) : (
                            /*TEXT*/
                            <div dangerouslySetInnerHTML={{ __html: props?.post?.Text }} />
                        )}
                    </div>
                </div>
                <div className="row m-0 p-0 pe-1">
                    <div>
                        {(((authContext?.user?.Id == props?.post?.Aurthor?.Id && moment(props?.post?.Time) + oneHour) > (new Date)) || authContext?.user?.HasAuthority) ? (
                            <div>
                                <button className="btn btn-link text-danger float-end" onClick={() => onDelete(props?.post?.Id)}>
                                    <FontAwesomeIcon icon={faTrash} />
                                </button>
                                <button className="btn btn-link float-end" onClick={() => onEditClick(props?.post)}>
                                    <FontAwesomeIcon icon={faPencilSquare} />
                                </button>
                            </div>
                        ) : (
                            <button className="btn btn-link float-end" onClick={() => onReport(props?.post.Id)}>
                                <FontAwesomeIcon icon={faFlag} />                                    
                            </button>
                        )}
                        {authContext?.user?.Id != props?.post?.Aurthor?.Id && (
                            <button className="btn btn-link float-end" onClick={() => props.onQuote(props?.post)}>
                                <FontAwesomeIcon icon={faQuoteRight} />
                            </button>
                        )}
                    </div>
                </div>
            </div> 
        </div>
    );
}

export default Post;