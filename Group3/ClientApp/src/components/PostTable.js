import React, { Components, useEffect, useState } from 'react';

export const PostTable = props => {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Date</th>
                    <th>Topic</th>
                    <th>Text</th>
                    <th>User</th>                    
                </tr>
            </thead>
            <tbody>
                {
                    props.posts.map(post =>
                        <tr key={post.Id}>
                            <td>{post.Id}</td>
                            <td>{post.Time}</td>
                            <td>{post.Topic.Name}</td>
                            <td>{post.Text}</td>
                            <td>{post.User.Name}</td>                           
                        </tr>
                    )
                }
            </tbody>
        </table>
    );
}