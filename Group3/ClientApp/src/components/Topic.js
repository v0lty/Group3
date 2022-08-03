import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";
import API from "./API";
import { useParams } from 'react-router';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';
import parse from 'html-react-parser'
import PostComponent from './PostComponent';
import RichTextEditor from 'react-rte'; // https://github.com/sstur/react-rte

export default function Topic() {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const [topic, setTopic] = useState(null);
    const [posts, setPosts] = useState([]);
    const [value, setValue] = useState(RichTextEditor.createEmptyValue());

    const updateTopic = async () => {
        API.getTopicById({
            topicId: id,
        }).then((topic) => {
            setTopic(topic);
            updatePosts(topic.Id);
        });
    }

    const updatePosts = async (id) => {
        API.getPostsByTopic({
            topicId: id,
        }).then((posts) => {
            setPosts(posts);
        });
    }

    useEffect(() => {
        updateTopic();        
    }, [id])

    const onFormDelete = async (id) => {
        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }
        API.deletePost({ postId: id }).then(() => {
            updateTopic();
        });
    }

    const onReply = async (id) => {
    }

    const onChange = (value) => {
        setValue(value);
    };

    const onSendClick = () => {
        API.createPost({
            text: value.toString('html'),
            userId: authContext.user.Id,
            topicId: topic?.Id
        }).then(() => {
            setValue(RichTextEditor.createEmptyValue());
            updateTopic();
        });
    }

    return (
        <div>
            <div className="p-3">
                <h5>{topic?.Category?.Name + ' > ' + topic?.Name}</h5>
            </div>
            {posts?.map((post, postIndex) =>
                <PostComponent key={postIndex} post={post} onDelete={onFormDelete} onReply={onReply} />
            )}
            <div className="border-top">
                <RichTextEditor className="mt-3" value={value} onChange={onChange} required />
                <button onClick={onSendClick}>Send</button>
            </div>
        </div>
    );
}