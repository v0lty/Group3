import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { PostTable } from './PostTable'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { AuthContext } from "./UserAuthentication";
import RichTextEditor from 'react-rte';

export default function Forum() {
    const authContext = useContext(AuthContext);
    const [posts, setPosts] = useState([]);
    const [topics, setTopics] = useState([]);
    const [value, setValue] = useState(RichTextEditor.createEmptyValue());

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
            text: value.toString('html'),
            userId: authContext.user.Id,
            topicId: event.target.elements['formTopic'].value
        }).then(() => {
            setValue(RichTextEditor.createEmptyValue());
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

    const onChange = (value) => {
        setValue(value); 
        console.log(value.toString('html'));
    };

    const toolbarConfig = {
        // Optionally specify the groups to display (displayed in the order listed).
        display: ['INLINE_STYLE_BUTTONS', 'BLOCK_TYPE_BUTTONS', 'LINK_BUTTONS', 'BLOCK_TYPE_DROPDOWN', 'HISTORY_BUTTONS'],
        INLINE_STYLE_BUTTONS: [
            { label: 'Bold', style: 'BOLD', className: 'custom-css-class' },
            { label: 'Italic', style: 'ITALIC' },
            { label: 'Underline', style: 'UNDERLINE' }
        ],
        BLOCK_TYPE_DROPDOWN: [
            { label: 'Normal', style: 'unstyled' },
            { label: 'Heading Large', style: 'header-one' },
            { label: 'Heading Medium', style: 'header-two' },
            { label: 'Heading Small', style: 'header-three' }
        ],
        BLOCK_TYPE_BUTTONS: [
            { label: 'UL', style: 'unordered-list-item' },
            { label: 'OL', style: 'ordered-list-item' }
        ]
    };

    return (
        <div>
            <Form onSubmit={onFormSubmit}>
                <Form.Group className="m-2" controlId="formTopic">
                    <Form.Label>Topic</Form.Label>
                    <Form.Select className="p-2 border border-info rounded w-100" defaultValue='0' required>
                        {topics?.map((topic, index) =>
                            <option key={topic.Id} value={topic.Id}>{topic.Name}</option>
                        )}
                    </Form.Select>
                </Form.Group>
                <Form.Group className="m-2" controlId="formText">
                    <RichTextEditor
                        value={value}
                        onChange={onChange}
                        toolbarConfig={toolbarConfig}
                        required />
                </Form.Group>
                <Button className="m-2" type="submit">Send</Button>
            </Form>
            <PostTable posts={posts} onDelete={onFormDelete} />
        </div>
    );
}