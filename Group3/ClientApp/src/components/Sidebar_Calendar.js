import DatePicker from 'sassy-datepicker';
import API from "./API";
import React, { useContext, useState } from 'react';
import moment from "moment";

export default function Sidebar_Latest() {
    const [posts, setPosts] = useState([]);

    const onChange = (date) => {

        API.getPostsByDate({
            date: date.getTime(),
        }).then((posts) => {
            console.log(posts);
            setPosts(posts);
            
        });
    };

    return (
        <div>
            {posts?.map(post =>

                <a>{moment((post?.Time)).format("DD/MM/yyyy")} - {post.Aurthor.FirstName} : {post.Text} </a>

            )}
            <DatePicker onChange={onChange} />

      
        </div>
    );
}