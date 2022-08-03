import React, { useState, useContext, useEffect } from 'react';
import UserComponent from './UserComponent';
import { AuthContext } from "./UserAuthentication";
import parse from 'html-react-parser'

export const PostComponent = props => {
    const authContext = useContext(AuthContext);

    useEffect(() => {
    }, [])

    return (
        <div className="">
            <div className="row bg-gray p-1">
                <span>{props?.post?.Time}</span>
            </div>
            <div className="row">
                <div className="col-2">
                    <UserComponent user={ props?.post?.Aurthor } />
                </div>
                <div className="col-10">
                    <p>{parse(props?.post?.Text)}</p>
                </div>
                <div className="row">
                    <div>
                        {authContext.user.Id == props?.post?.Aurthor.Id && (
                            <button className="btn btn-link" onClick={() => props.onDelete(props?.post.Id)} className="float-end">Delete</button>
                        )}
                        {authContext.user.Id != props?.post?.Aurthor.Id && (
                            <button className="btn-link" onClick={() => props.onReply(props?.post.Id)} className="float-end">Reply</button>
                        )}
                    </div>
                </div>
            </div>
 
        </div>
    );
}

export default PostComponent;