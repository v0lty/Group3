import React, { useContext, useState, useEffect } from 'react';
import moment from "moment";
import UserComponent from '../UserComponent';
import AuthContext from "../UserAuthentication";
import RichTextEditor from 'react-rte';
import API from "../API";
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";

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
        <Post post={post} onEdit={updatePost} onDelete={() => { history.push('/'); }}/>
    );
}

// PROPS
export const Post = props => {
    const authContext = useContext(AuthContext);
    const [editMode, setEditMode] = useState(false);
    const [editPost, setEditPost] = useState(null);
    const [value, setValue] = useState(RichTextEditor.createEmptyValue());
   
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
            + `<span><i>Last edited by ${authContext?.user?.Name}@ ${moment(moment.now()).format('YYYY/MM/DD HH:mm:ss')}</i></span><br/>`;

        API.editPost({
            postId: editPost.Id,
            postText: text
        }).then(() => {
            setValue(RichTextEditor.createEmptyValue());
            setEditMode(!editMode);
            props?.onUpdate();
        });
    };

    const onDelete = async (id) => {
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
            alert("Post reported, thank you!");
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
        <div className="mb-4 bg-gray">
            <div className="row p-2">
                <div>
                    <span>{moment(props?.post?.Time).fromNow()}</span>                  
                    {/*<button className="btn border-0 float-end p-0 px-2">{Math.floor(Math.random() *  5)} &#128078;</button> */}               
                    <button className="btn border-0 float-end p-0 px-2" onClick={() => onVote(props?.post?.Id)}>{props?.post?.Votes} &#128077;</button>
                </div>
            </div>
            <div className="row">
                <div className="col-2" style={{ minWidth: 175}}>
                    <UserComponent user={ props?.post?.Aurthor } />
                </div>
                <div className="col px-4">
                    <div className="bg-light p-2 pb-2 h-100">
                        {editMode == true && (
                            <div>
                                <RichTextEditor className="new-post-editor" value={value} onChange={onChange} />
                                <button className="btn btn-secondary my-2" onClick={onSave}>Save</button>
                            </div>
                        )}
                        {editMode == false && (
                            <div dangerouslySetInnerHTML={{ __html: props?.post?.Text }} />
                        )}
                        
                    </div>
                </div>
                <div className="row">
                    <div>
                        {(authContext?.user?.Id == props?.post?.Aurthor?.Id || authContext?.user?.HasAuthority) && (
                            <div>                                
                                <button className="btn btn-link float-end" onClick={() => onDelete(props?.post?.Id)}>Delete</button>
                                <button className="btn btn-link float-end" onClick={() => onEditClick(props?.post)}>Edit</button>
                            </div>
                        )}
                        {authContext?.user?.Id != props?.post?.Aurthor?.Id && (
                            <div>                                
                                <button className="btn btn-link float-end" onClick={() => props.onQuote(props?.post)}>Quote</button>
                                <button className="btn btn-link float-end" onClick={() => onReport(props?.post.Id)}>Report</button>
                            </div>
                        )}
                    </div>
                </div>
            </div> 
        </div>
    );
}

export default Post;