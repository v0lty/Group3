import React, { Component, useState } from 'react';
import Home from './components/Home';
import Menu from './components/Menu';
import Forum from './components/Forum';
import Login from './components/Login';
import { Route } from 'react-router';
import { Container } from 'reactstrap';
import { AuthContext } from "./components/Context";

import './custom.css'

export default function App() {
    const [user, setUser] = useState(null);

    const signInHandler = (user) => {
        setUser(user);
    };

    const signOutHandler = () => {
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
            </Container>
        </AuthContext.Provider>
    );
}