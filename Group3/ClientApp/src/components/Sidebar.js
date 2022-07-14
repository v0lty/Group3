import React, { useState, useContext, useEffect } from 'react';

import CategoriesView from "./sidebar/CategoriesView";
import TopicsView from "./sidebar/TopicsView";

export default function Sidebar() {

    return (
        <div>
            <CategoriesView />
            <TopicsView />
        </div>
    );
}