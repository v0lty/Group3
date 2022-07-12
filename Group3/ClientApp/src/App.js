import React, { Component, useState, useEffect } from 'react';
import Home from './components/Home';
import Menu from './components/Menu';
import Forum from './components/Forum';
import Profile from './components/Profile';
import Messages from './components/Messages';
import Category from './components/Category';
import Topic from './components/Topic';
import { Route } from 'react-router';
import { Container } from 'reactstrap';
import { AuthContextProvider } from "./components/UserAuthentication";
import { usePromiseTracker } from "react-promise-tracker";
import Spinner from 'react-bootstrap/Spinner'
import Sidebar from './components/Sidebar';

import './custom.css'

const LoadingIndicator = props => {
    const { promiseInProgress } = usePromiseTracker();
    return (promiseInProgress &&
        <Spinner animation="border" role="status">
            <span className="visually-hidden">Loading...</span>
        </Spinner>
    );
}

export default function App() {
    return (
        <AuthContextProvider>
            <Menu />            
            <Container>
                <Route exact path='/'>         
                    <div className="row pt-2">
                        <div className="col-2 sidenav">
                            <Sidebar />
                        </div>
                        <div className="col-8">
                            <Home />
                        </div>
                        <div className="col-2" / >
                    </div>
                </Route>
                <Route exact path='/forum'>
                    <Forum />
                </Route>
                <Route exact path='/profile'>
                    <Profile />
                </Route>
                <Route exact path='/messages'>
                    <Messages />
                </Route>
                <Route exact path='/category/:id'>
                    <Category />
                </Route>
                <Route exact path='/topic/:id'>
                    <Topic />
                </Route>
                <LoadingIndicator />
            </Container>
        </AuthContextProvider>
    );
}