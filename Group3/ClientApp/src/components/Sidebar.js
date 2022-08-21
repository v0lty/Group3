import React, { useState, useContext, useEffect } from 'react';

import Sidebar_LatestNews from "./Sidebar_LatestNews";
import Sidebar_Events from "./Sidebar_Events";
import Sidebar_LatestPosts from "./Sidebar_LatestPosts";
import Sidebar_MostLikes from "./Sidebar_MostLikes";

export const SidebarLeft = () => {
    return (
        <div>
            {/*<Sidebar_Categories />*/}
            <Sidebar_LatestPosts />
            <Sidebar_MostLikes />
        </div>
    );
}

export const SidebarRight = () => {
    return (
        <div>  
            <Sidebar_LatestNews />
            <Sidebar_Events />
            {/*<Sidebar_Subjects />*/}
            {/*<Sidebar_Calendar />*/}
        </div>
    );
}