import React, { Components, useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import parse from 'html-react-parser'

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
                    <th>Action</th>
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
                            <td> <div> {parse(post?.Text)}</div></td>
                            <td><Button className="" onClick={() => props.onDelete(post.Id)}>Delete</Button></td>
                        </tr>
                    )
                }
            </tbody>
        </table>
    );
}