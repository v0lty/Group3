import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "./UserAuthentication";

import API from "./API";

export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);
  
    const updateNews = async () => {
        API.getNews().then((newsCategory) => {
            console.log(newsCategory);
            setNewsCategory(newsCategory);
        });
    }

    useEffect(() => {
        updateNews();
    }, [])

    return (
        <div>
            {newsCategory?.Topics.map(topic =>
                <p>{topic?.Name}</p>
            )}
        </div>
    
    );
}