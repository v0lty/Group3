import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import { useHistory } from "react-router-dom";
import API from "./API";
import moment from "moment";

export default function Sidebar_LatestPosts() {
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
        return str.length > 35 ? str.substring(0, 33) + ".." : str;
    }

    if (posts == null || posts.length == 0) {
        return (<div />);
    }
    else {
        return (
            <div className="bg-white shadow mb-4">
                <div className="p-2 text-center">
                    <h6>LATEST POSTS</h6>
                </div>
                <div className="">
                    {posts?.map(post =>
                        <div key={post.Id} className="sidebar-item d-flex border-0 border-top pt-2" onClick={() => onPostClick(post.Id)}>
                            <div className="col-2" style={{ width: 55 }}>
                                <div className="ps-2"  >
                                    <img className="profile-image-extra-small" src={`../Pictures/${post?.Author.ProfilePicture?.Path}`}></img>
                                </div>
                            </div>
                            <div className="col">
                                <div className="d-flex justify-content-between align-items-start">
                                    <span className="fw-bold">{post.Author.FirstName}</span>
                                    <div className="pe-2">
                                        <div className="badge rounded-pill bg-info" >
                                            <span>{moment(post.Time).fromNow()}</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="row">
                                   <div className="sidebar-text" dangerouslySetInnerHTML={{ __html: truncate(post.Subject.Name) }} />
                                </div>

                            </div>
                        </div>
                    )}
                </div>
            </div>
        );
    }
}