import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import { useParams } from 'react-router';
import Post from './Post';
import InputModal from '../InputModal';
import moment from "moment";

export default function Topic() {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const [topic, setTopic] = useState(null);
    const [input, setInput] = useState("");
    const [posts, setPosts] = useState([]);
    const [modalVisible, setModalVisible] = useState(false);

    useEffect(() => {
        updateTopic();
    }, [id])

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

    const onPostQuote = (post) => {
        setInput(
            `<blockquote>
                <span>
                    Quote by<a href="/post/${post.Id}">
                        ${post.Aurthor.Name} @ 
                        ${moment(post.Time).utc().format('YYYY/MM/DD HH:mm')}
                    </a><br />
                    ${post.Text}
                </span>                                     
             </blockquote>`
        );
        setModalVisible(!modalVisible)
    }

    const onCreatePostSubmit = (text) => {
        API.createPost({
            text: text,
            userId: authContext.user.Id,
            topicId: topic?.Id
        }).then(() => {
            setInput("");
            updateTopic();
            setModalVisible(!modalVisible)
        });
    }

    return (
        <div className="p-3">         
            <h5 className="m-0 p-0 pb-3">{topic?.Category?.Name + ' > ' + topic?.Name}</h5>         
            {posts?.map((post, postIndex) =>
                <Post
                    key={postIndex}
                    post={post}        
                    onUpdate={() => { updateTopic(); }}
                    onQuote={onPostQuote}
                />
            )}
            <div className="border-top">
                <InputModal                    
                    title="Create Post"
                    input={input}
                    onSubmit={onCreatePostSubmit}
                    visible={modalVisible}
                    onHide={() => { setModalVisible(!modalVisible); }}
                />
                <button
                    className="btn btn-link my-2"
                    onClick={() => { setModalVisible(!modalVisible); }}>
                    Create new Post
                </button>
            </div>
        </div>
    );
}