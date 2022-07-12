import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { PostTable } from './PostTable'
import { PostForm } from './PostForm'
import { AuthContext } from "./UserAuthentication";

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [posts, setPosts] = useState([]);
    const [topics, setTopics] = useState([]);

    const updateTopics = async () => {
        API.getAllTopics().then((topics) => {
            setTopics(topics);
        });
    }

    const updatePosts = async () => {
        API.getAllPosts().then((posts) => {
            setPosts(posts);
        });

        API.getAllCategories()
    }

    useEffect(() => {
        updateTopics();
        updatePosts();
    }, [])

    const onFormSubmit = async (event) => {
        event.preventDefault();

        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }

        API.createPost({
            text: event.target.elements['formText'].value,
            userId: authContext.user.Id,
            topicId: event.target.elements['formTopic'].value
        }).then(() => {
            updatePosts();
        });
    }

    const onFormDelete = async (id) => {

        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }

        API.deletePost({postId: id}).then(() => {
            updatePosts();
        });
    }

    return (
        <div>
            <PostForm topics={topics} onSubmit={onFormSubmit} />
            <PostTable posts={posts} onDelete={onFormDelete} />
        </div>
    );
}