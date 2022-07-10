import React, { createContext, useContext, useState } from 'react';
import axios from 'axios'

export const AuthContext = createContext({
    user: null,
    setUser: () => { }
});

export const AuthContextProvider = (props) => {
    const setUser = (user) => {
        setState({ ...state, user: user })
    };
    const [state, setState] = useState({ user: null, setUser: setUser});
    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    )
}

export const queryCurrentUser = async () => {
    const response = await axios.get('http://localhost:13021/API/QueryCurrentUser');
    return JSON.parse(response.data);
}