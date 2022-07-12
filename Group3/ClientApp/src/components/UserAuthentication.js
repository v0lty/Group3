import React, { createContext, useContext, useState } from 'react';

export const AuthContext = createContext({
    user: null,
    setUser: () => { }
});

export const AuthContextProvider = (props) => {
    const setUser = (user) => {
        setState({ ...state, user: user });
    };
    const [state, setState] = useState({ user: null, setUser: setUser });
    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    )
}