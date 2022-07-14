import React from 'react';
import Home from './components/Home';
import Menu from './components/Menu';
import Footer from './components/Footer';
import Forum from './components/Forum';
import Profile from './components/Profile';
import Messages from './components/Messages';
import Category from './components/Category';
import Topic from './components/Topic';
import { Route } from 'react-router';
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
            <div className="d-flex flex-column overflow-hidden content">
                <Menu />
                <div className="flex-grow-1 overflow-auto p-2 mt-3">                    
                    <div className="row m-0 p-0">
                        <div className="col-2">
                            <Sidebar />
                        </div>
                        <div className="col-8">
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
                            <Route exact path='/profile'>
                                <Profile />
                            </Route>
                            <Route exact path='/messages'>
                                <Messages />
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