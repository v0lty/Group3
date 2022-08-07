﻿import React, { useState, useContext, useEffect } from 'react';

import Sidebar_Categories from "./Sidebar_Categories";
import Sidebar_News from "./Sidebar_News";
import Sidebar_Latest from "./Sidebar_Latest";
import Sidebar_Subjects from "./Sidebar_Subjects";
import Sidebar_Posts from "./Sidebar_Posts";

export const SidebarLeft = () => {
    return (
        <div>
            <Sidebar_Latest />
            <Sidebar_Posts />
            
        </div>
    );
}

export const SidebarRight = () => {
    return (
        <div>            
            <Sidebar_Categories />
            <Sidebar_News />            
            <Sidebar_Subjects />
        </div>
    );
}