

import React, { Components, useEffect, useState } from 'react';

export const PostTable = props => {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Date</th>
                    <th>Text</th>
                </tr>
            </thead>
            <tbody>
                {
                    props.posts.map(post => 
                        <tr key={ post.Id }>
                            <td>{post.Id}</td>
                            <td>{post.Time}</td>
                            <td>{post.Text}</td>
                        </tr>
                        )
                }
            </tbody>
        </table>
        );
}


