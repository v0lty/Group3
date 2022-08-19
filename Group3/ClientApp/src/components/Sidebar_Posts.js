import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export default function Sidebar_Posts() {
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
        return str.length > 23 ? str.substring(0, 20) + " ..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">
            <div className="">
                <h6 style={{ color: "#1c4966" }}>MOST LIKES</h6>
            </div>
            <ListGroup as="ul" className="shadow" >
                {posts.reverse().map(post =>
                    <ListGroup.Item key={post.Id} as="li" className="d-flex justify-content-between align-items-start border-0 border-top shadow" onClick={() => onPostClick(post.Id)}>
                        <div className="col-3" style={{ width: 45 }}>
                            <img className="profile-image-extra-small" src={`../Pictures/${post?.Aurthor.ProfilePicture?.Path}`}></img>
                        </div>
                        <div className="col">
                            <div className="row">
                                <div className="col">
                                    <span className="fw-bold">{post.Aurthor.FirstName}</span>
                                </div>
                                <div className="col-4 p-0 d-flex justify-content-end">
                                    <Badge bg="light" className="bg-white text-dark" pill>
                                        {post.Votes} &#128077;
                                    </Badge>
                                </div>
                            </div>
                            <div className="p-0 m-0">
                                <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(post.Text) }} />
                            </div>
                        </div>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}