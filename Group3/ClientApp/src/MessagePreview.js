import React, { useState, useContext, useEffect } from 'react';
import API from "./API";

export default function MessagePreview(props) {
    const [topic, setTopic] = useState(null);

    const updateTopic = async () => {
        API.getTopicById({
            topicId: id,
        }).then((topic) => {
            setTopic(topic);
        });
    }

    useEffect(() => {
        updateTopic();
    }, [id])

    return (
        <div>
            <strong></strong>
        </div>
    );
}