import React, { useState, useContext, useEffect } from 'react';

import Sidebar_Categories from "./Sidebar_Categories";
import Sidebar_News from "./Sidebar_News";
import Sidebar_Events from "./Sidebar_Events";
import Sidebar_Latest from "./Sidebar_Latest";
import Sidebar_Subjects from "./Sidebar_Subjects";
import Sidebar_Posts from "./Sidebar_Posts";
import Sidebar_Calendar from "./Sidebar_Calendar";



export const SidebarLeft = () => {
    return (
        <div>
            {/*<Sidebar_Categories />*/}
            <Sidebar_Latest />            
            <Sidebar_Posts />
            <Sidebar_News />
        </div>
    );
}

export const SidebarRight = () => {
    const [fakeCurrentDate, setFakeCurrentDate] = useState(new Date()) // default value can be anything you want

    useEffect(() => {
        setTimeout(() => setFakeCurrentDate(new Date()), 10000)
    }, [fakeCurrentDate])


    return (
        <div>  
            <Sidebar_News />
            <Sidebar_Events />
            {/*<Sidebar_Subjects />*/}
            {/*<Sidebar_Calendar />*/}
        </div>
    );
}