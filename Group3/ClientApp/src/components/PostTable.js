import React, { Components, useEffect, useState } from 'react';

export const PostTable = props => {
    return (
        <table className='table mt-3'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>User</th>
                    <th>Date</th>
                    <th>Category</th>
                    <th>Topic</th>
                    <th>Text</th>                                    
                </tr>
            </thead>
            <tbody>
                {
                    props.posts.map(post =>
                        <tr key={post.Id}>
                            <td>{post.Id}</td>
                            <td>{post.User.Name}</td>
                            <td>{post.Time}</td>
                            <td>{post.Topic.Category.Name}</td>
                            <td>{post.Topic.Name}</td>
                            <td>{post.Text}</td>                                                   
                        </tr>
                    )
                }
            </tbody>
        </table>
    );
}