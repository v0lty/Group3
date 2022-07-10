import React, { useState, useContext, useEffect  } from 'react';
import { PostTable } from './PostTable'
import { PostForm } from './PostForm'
import { AuthContext } from "./UserAuthentication";
import axios from 'axios'

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [posts, setPosts] = useState([]);
    const [topics, setTopics] = useState([]);
    const baseURL = 'http://localhost:13021/API/';

    const updateTopics = async () => {
        await axios.get(baseURL + 'GetAllTopics').then((response) => {
            setTopics(JSON.parse(response.data));           
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
            setTopics([]);
        });
    }

    const updatePosts = async () => {

        await axios.get(baseURL + 'GetAllPosts').then((response) => {         
            setPosts(JSON.parse(response.data));            
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
            setPosts([]);
        });
    }

    useEffect(() => {
        updateTopics();
        updatePosts();
    }, [])

    const onFormSubmit = async (e) => {
        e.preventDefault();

        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }
        
        axios.post(baseURL + 'CreatePost', null, {
            params: {
                text: e.target.elements['formText'].value,
                userId: authContext.user.Id,
                topicId: e.target.elements['formTopic'].value
            }
        }).then((response) => {
            updatePosts();
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
        });
    }

    const onFormDelete = async (id) => {

        if (authContext.user == null) {
            alert("You need to sign in first!");
            return;
        }

        axios.post(baseURL + 'DeletePost', null, {
            params: {
                postId: id,
            }
        }).then((response) => {
            updatePosts();
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
        });
    }

    return (
        <div>
            <PostForm topics={topics} onSubmit={onFormSubmit} />
            <PostTable posts={posts} onDelete={onFormDelete} />
        </div>
    );
}
