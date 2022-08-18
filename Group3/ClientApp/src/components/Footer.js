import React, { useState, useContext, useEffect } from 'react';
import API from "./API";
import { useHistory } from "react-router-dom";

export default function Footer() {
    const history = useHistory();

    return (
        <footer className="border-top p-3">            
            <div className="d-flex justify-content-center">
                <a href="#" className="fa fa-facebook"></a>
                <a href="#" className="fa fa-twitter"></a>
                <a href="#" className="fa fa-google"></a>
                <a href="#" className="fa fa-instagram"></a>
      
                <a type="application/rss+xml" href="http://localhost:13021/feed.xml" className="fa fa-rss-square" target="_blank" ></a>
            </div>
            <span>&copy; {new Date().toLocaleDateString()}</span>
        </footer>
    );
}