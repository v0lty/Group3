import React, { createContext, useContext, useState } from 'react';

export const AuthContext = createContext({
    user: null,
    setUser: () => { },
    initialed: false,
});

export const AuthContextProvider = (props) => {
    const setUser = (user) => {
        setState({ ...state, user: user, initialed: true });
    };
    const [state, setState] = useState({ user: null, setUser: setUser });
    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    )
}

export default AuthContext;