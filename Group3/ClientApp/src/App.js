import React, { Component, useState, useEffect } from 'react';
import Home from './components/Home';
import Menu from './components/Menu';
import Forum from './components/Forum';
import Login from './components/Login';
import Profile from './components/Profile';
import Messages from './components/Messages';
import { Route } from 'react-router';
import { Container } from 'reactstrap';
import { AuthContext } from "./components/Context";
import axios from 'axios'

import './custom.css'

export default function App() {
    const [user, setUser] = useState(null);

    const getUser = async () => {
        await axios.get('http://localhost:13021/API/GetUser').then((response) => {
            setUser(JSON.parse(response.data));
        }).catch((error) => {
            setUser(null);
        });
    }    
    const signOut = async () => {
        await axios.get('http://localhost:13021/API/SignOut').then((response) => {
        }).catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
        });
    }

    useEffect(() => {
        // TODO: await function
        getUser();
    }, [])

    const signInHandler = (user) => {
        setUser(user);
    };

    const signOutHandler = () => {
        signOut();
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ signIn: signInHandler, signOut: signOutHandler, user: user }}>
            <Menu />
            <Container>
                <Route exact path='/'>
                    <Home />
                </Route>
                <Route exact path='/forum'>
                    <Forum />
                </Route>
                <Route exact path='/login'>
                    <Login />
                </Route>
                <Route exact path='/profile'>
                    <Profile />
                </Route>
                <Route exact path='/messages'>
                    <Messages />
                </Route>
            </Container>
        </AuthContext.Provider>
    );
}