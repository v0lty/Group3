import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { useHistory } from "react-router-dom";

export default function Footer() {
    const history = useHistory();

    const onRSSClick = (event) => {
        event.preventDefault();
        API.getRSS().then((file) => {
            // NOTE: APIController causing refresh for some reason (probably filesream) but you can 
            // manualy access the file after API call at localhost:port/feed.xml         
            history.push("/" + file);
        });
    };

    return (
        <footer className="border-top p-3">            
            <div className="d-flex justify-content-center">
                <a href="#" className="fa fa-facebook"></a>
                <a href="#" className="fa fa-twitter"></a>
                <a href="#" className="fa fa-google"></a>
                <a href="#" className="fa fa-instagram"></a>
                <a onClick={onRSSClick} className="fa fa-rss-square"></a>
            </div>
            <span>&copy; {new Date().toLocaleDateString()}</span>
        </footer>
    );
}