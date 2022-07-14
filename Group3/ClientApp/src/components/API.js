import axios from 'axios'
import { trackPromise } from 'react-promise-tracker';

// API CALLS HERE:

const baseURL = 'http://localhost:13021/API/';

const API = {
    getCurrentUser: async () => { 
        return trackPromise(get(baseURL + 'GetCurrentUser'));
    },
    signIn: async (params) => {
        return trackPromise(post(baseURL + 'SignIn', params));
    },
    signOut: async () => {
        return trackPromise(get(baseURL + 'SignOut'));
    },
    getAllTopics: async () => {
        return trackPromise(get(baseURL + 'GetAllTopics'));
    },
    getAllPosts: async () => {
        return trackPromise(get(baseURL + 'GetAllPosts'));
    },
    createPost: async (params) => {
        return trackPromise(post(baseURL + 'CreatePost', params));
    },
    deletePost: async (params) => {
        return trackPromise(post(baseURL + 'DeletePost', params));
    },
    getAllCategories: async () => {
        return trackPromise(get(baseURL + 'GetAllCategories'));
    },
    getCategoryById: async (params) => {
        return trackPromise(post(baseURL + 'GetCategoryById', params));
    },
    getTopicById: async (params) => {
        return trackPromise(post(baseURL + 'GetTopicById', params));
    },
    getHotTopics: async () => {
        return trackPromise(get(baseURL + 'GetHotTopics'));
    },
    editUser: async (params) => {
        return trackPromise(post(baseURL + 'EditUser', params));
    },
}

export const get = (url) => {
    const promise = new Promise((resolve, reject) => {
        console.log('Sending GET: ' + url);
        resolve(axios.get(url)
            .then((response) => response.data)
            .catch((error) => {
                if (window.confirm(error + '\nMessage: ' + error.response.data.responseText + '\n\nRetry?')) {
                    // recursive call
                    return get(url);
                }
            }));
    });
    return promise;
}

export const post = (url, params) => {
    const promise = new Promise((resolve, reject) => {
        console.log('Sending POST: ' + url + ' Params: ', params);
        resolve(axios.post(url, null, { params: params })
            .then((response) => response.data)
            .catch((error) => {
                if (window.confirm(error + '\nMessage: ' + error.response.data.responseText + '\n\nRetry?')) {
                    // recursive call
                    return post(url, params);
                }
            }));
    });
    return promise;
}

export default API;
