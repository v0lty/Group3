import { createContext } from "react";

export const AuthContext = createContext({
    user: null,
    signIn: (user) => { },
    signOut: () => { }
});
