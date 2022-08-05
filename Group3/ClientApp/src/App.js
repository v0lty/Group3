import React from 'react';
import Home from './components/Pages/Home';
import Menu from './components/Menu';
import Footer from './components/Footer';
import Forum from './components/Pages/Forum';
import Profile from './components/Pages/Profile';
import Messages from './components/Pages/Messages';
import Category from './components/Pages/Category';
import Topic from './components/Pages/Topic';
import { Route } from 'react-router';
import { AuthContextProvider } from "./components/UserAuthentication";
import { usePromiseTracker } from "react-promise-tracker";
import Spinner from 'react-bootstrap/Spinner'
import Sidebar from './components/Sidebar';
import Signup from './components/Pages/Signup';
import { Post, PostPath } from './components/Pages/Post';
import Managment from './components/Pages/Managment';

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
            <div className="d-flex flex-column overflow-hidden content">
                <Menu />
                <div className="flex-grow-1 overflow-auto p-2 mt-3">                    
                    <div className="row m-0 p-0">
                        <div className="col-2" style={{ minWidth: 250 }}>
                            <Sidebar />
                        </div>
                        <div className="col">
                            <Route exact path='/'>
                                <Home />
                            </Route>  
                            <Route exact path='/forum'>
                                <Forum />
                            </Route>
                            <Route exact path='/category/:id'>
                                <Category />
                            </Route>
                            <Route exact path='/topic/:id'>
                                <Topic />
                            </Route>
                            <Route exact path='/post/:id'>
                                <PostPath />
                            </Route>
                            <Route exact path='/profile'>
                                <Profile />
                            </Route>
                            <Route exact path='/messages'>
                                <Messages />
                            </Route>
                            <Route exact path='/signup'>
                                <Signup />
                            </Route>
                            <Route exact path='/managment'>
                                <Managment />
                            </Route>
                            <div className="d-flex justify-content-center">
                                <LoadingIndicator />
                            </div>                            
                        </div>
                        <div className="col-2" />
                    </div>   
                </div>
                <Footer / >
            </div>
        </AuthContextProvider>
    );
}