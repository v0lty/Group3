import React, { useState, useContext, useEffect } from 'react';

export default function Footer() {
  
    return (
        <footer className="border-top p-3">            
            <div className="d-flex justify-content-center">
                <a href="#" className="fa fa-facebook"></a>
                <a href="#" className="fa fa-twitter"></a>
                <a href="#" className="fa fa-google"></a>
                <a href="#" className="fa fa-instagram"></a>
            </div>
            <span>&copy; {new Date().toLocaleDateString()}</span>
        </footer>
    );
}