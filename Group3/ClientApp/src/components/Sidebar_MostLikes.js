import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API, { post } from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faThumbsUp } from '@fortawesome/free-solid-svg-icons'

export default function Sidebar_MostLikes() {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [posts, setPosts] = useState([]);    

    const updatePosts = async () => {
        API.getHotPosts().then((posts) => {            
            setPosts(posts);
        });
    }

    useEffect(() => {
        updatePosts();
    }, [])

    const onPostClick = (id) => {
        history.push('/post/' + id);
    }

    const truncate = (str) => {
        return str.length > 28 ? str.substring(0, 26) + " .." : str;
    }

    if (posts == null || posts.length == 0) {
        return (<div />);
    }
    else {
        return (
            <div className="bg-white shadow mb-4">
                <div className="p-2 text-center">
                    <h6>MOST LIKES</h6>
                </div>
                <div className="">
                    {posts?.map(post =>
                        <div key={post.Id} className="sidebar-item d-flex border-0 border-top pt-2" onClick={() => onPostClick(post.Id)}>
                            <div className="col-2" style={{ width: 55 }}>
                                <div className="ps-2"  >
                                    <img className="profile-image-extra-small" loading="lazy" src={`../Pictures/${post?.Author.ProfilePicture?.Path}`}></img>
                                </div>
                            </div>
                            <div className="col">
                                <div className="d-flex justify-content-between align-items-start">
                                    <span className="fw-bold">{post.Author.FirstName}</span>
                                    <Badge bg="light" className="bg-white text-dark" pill>
                                        {post.Votes} <FontAwesomeIcon className="text-warning pe-1" icon={faThumbsUp} />
                                    </Badge>
                                </div>
                                <div className="row">
                                    <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(post.Text) }} />
                                </div>
                            </div>
                        </div>
                    )}
                </div>
            </div>
        );
    }
}