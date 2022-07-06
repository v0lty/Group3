import React, { Component } from 'react';
import { PostTable } from './PostTable'
import axios from 'axios'
import {PostForm } from './PostForm'

export class Home extends Component {
    static displayName = Home.name;

    baseURL = 'http://localhost:13021/API/';

    constructor(props) {
        super(props);
        this.state = { posts: [] };
        this.updatePosts = this.updatePosts.bind(this);
        this.onPostFormSubmit = this.onPostFormSubmit.bind(this);
    }

    componentDidMount() {
        this.updatePosts();
    }

    async updatePosts() {
        await axios.get(this.baseURL + 'GetAllPosts').then((response) => {
        if (response.status == 200) {
            this.setState({ posts: JSON.parse(response.data) });
        }
    })
        .catch((error) => {
            alert(error + '\nMessage: ' + error.response.data.responseText);
            this.setState({ people: null, loading: true });
        });
    }

    onPostFormSubmit(e) {
        e.preventDefault();
        console.log(e);
    }

    render() {
        return (
            <div>
                <PostForm onSubmit={ this.onPostFormSubmit } />
                <PostTable posts={this.state.posts} />
            </div>
    );
  }
}
