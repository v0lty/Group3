import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";

import API from "../API";
import Category from './Category';

export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);
  
    const updateNews = async () => {
        API.getNews().then((newsCategory) => {
            setNewsCategory(newsCategory);
        });
    }

    useEffect(() => {
        updateNews();
    }, [])

    return (
        <div>
            <Category category={newsCategory} onUpdate={updateNews} />
        </div>
    
    );
}