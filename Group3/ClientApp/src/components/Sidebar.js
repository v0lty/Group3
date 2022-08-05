import React, { useState, useContext, useEffect } from 'react';

import CategoriesView from "./CategoriesView";
import TopicsView from "./TopicsView";

export default function Sidebar() {

    return (
        <div>
            <CategoriesView />
            <TopicsView />
        </div>
    );
}