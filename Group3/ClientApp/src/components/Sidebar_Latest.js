import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useHistory } from "react-router-dom";
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import moment from "moment";

export default function Sidebar_Latest() {
    const authContext = useContext(AuthContext);
    const history = useHistory();
    const [posts, setPosts] = useState([]);    

    const updatePosts = async () => {
        API.getLatestPosts().then((posts) => {
            setPosts(posts);
        });
    }

    useEffect(() => {
        updatePosts();
    }, [])

    const onPostClick = (id) => {
        history.push('/subject/' + id);
    }

    const truncate =(str) => {
        return str.length > 23 ? str.substring(0, 20) + "..." : str;
    }

    return (
        <div className="d-flex flex-column align-items-stretch border-0 mb-5">           
            <h6 style={{ color: "#1c4966" }}>LATEST POSTS</h6>
            <ListGroup as="ul" className="shadow">
                {posts.map(post =>
                    <ListGroup.Item key={post.Id} as="li" className="d-flex justify-content-between align-items-start border-0 shadow border-top" onClick={() => onPostClick(post.Subject.Id)}>
                        <div className="col-3" style={{ width: 45 }}>
                            <img className="profile-image-extra-small" src={`../Pictures/${post?.Aurthor.ProfilePicture?.Path}`}></img>
                        </div>
                        <div className="col">
                            <div className="row">
                                <div className="col">
                                    <span className="fw-bold">{post.Aurthor.FirstName}</span>
                                </div>
                                <div className="col p-0 pe-1 d-flex justify-content-end">
                                    <Badge bg="info" pill>
                                        <span>{moment(post.Time).fromNow()}</span>
                                    </Badge>
                                </div>
                            </div>
                            <div className="btn btn-link p-0 m-0">
                                <div dangerouslySetInnerHTML={{ __html: truncate(post.Subject.Name) }} />
                            </div>
                        </div>
                    </ListGroup.Item>
                )}
            </ListGroup>
        </div>
    );
}