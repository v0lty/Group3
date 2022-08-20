import React, { useState, useContext, useEffect } from 'react';

import Sidebar_News from "./Sidebar_News";
import Sidebar_Events from "./Sidebar_Events";
import Sidebar_Latest from "./Sidebar_Latest";
import Sidebar_Posts from "./Sidebar_Posts";

export const SidebarLeft = () => {
    return (
        <div>
            {/*<Sidebar_Categories />*/}
            <Sidebar_Latest />            
            <Sidebar_Posts />
        </div>
    );
}

export const SidebarRight = () => {
    return (
        <div>  
            <Sidebar_News />
            <Sidebar_Events />
            {/*<Sidebar_Subjects />*/}
            {/*<Sidebar_Calendar />*/}
        </div>
    );
}