import axios from 'axios'
import { trackPromise } from 'react-promise-tracker';

// API CALLS HERE:

const baseURL = '/API/';

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
    createEvent: async (params) => {
        return trackPromise(post(baseURL + 'CreateEvent', params));
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
    createUser: async (params) => {
        return trackPromise(post(baseURL + 'CreateUser', params));
    },
    getNews: async () => {
        return trackPromise(get(baseURL + 'GetNews'));
    },
    getLatestNews: async () => {
        return trackPromise(get(baseURL + 'GetLatestNews'));
    },
    getNextEvents: async () => {
        return trackPromise(get(baseURL + 'GetNextEvents'));
    },
    getMessages: async (params) => {
        return trackPromise(post(baseURL + 'GetMessages', params));
    },
    getChats: async (params) => {
        return trackPromise(post(baseURL + 'GetChats', params));
    },
    uploadFile: async (params) => {
        return trackPromise(postData(baseURL + 'UploadFile', params));
    },
    getUserPictures: async (params) => {
        return trackPromise(post(baseURL + 'GetUserPictures', params));
    },
    removePicture: async (params) => {
        return trackPromise(post(baseURL + 'RemovePicture', params));
    },
    getPostsByTopic: async (params) => {
        return trackPromise(post(baseURL + 'GetPostsByTopic', params));
    },
    createTopic: async (params) => {
        return trackPromise(post(baseURL + 'CreateTopic', params));
    },
    getPostById: async (params) => {
        return trackPromise(post(baseURL + 'GetPostById', params));
    },
    editPost: async (params) => {
        return trackPromise(post(baseURL + 'EditPost', params));
    },
    reportPost: async (params) => {
        return trackPromise(post(baseURL + 'ReportPost', params));
    },
    upVotePost: async (params) => {
        return trackPromise(post(baseURL + 'UpVotePost', params));
    },
    getSubjectById: async (params) => {
        return trackPromise(post(baseURL + 'GetSubjectById', params));
    },
    getHotSubjects: async (params) => {
        return trackPromise(get(baseURL + 'GetHotSubjects', params));
    },
    createSubject: async (params) => {
        return trackPromise(post(baseURL + 'CreateSubject', params));
    },
    deleteTopic: async (params) => {
        return trackPromise(post(baseURL + 'DeleteTopic', params));
    },
    deleteSubject: async (params) => {
        return trackPromise(post(baseURL + 'DeleteSubject', params));
    },
    getHotPosts: async (params) => {
        return trackPromise(get(baseURL + 'GetHotPosts', params));
    },
    getLatestPosts: async (params) => {
        return trackPromise(get(baseURL + 'GetLatestPosts', params));
    },
    createChatMessage: async (params) => {
        return trackPromise(post(baseURL + 'CreateChatMessage', params));
    },
    getAllUsers: async (params) => {
        return trackPromise(get(baseURL + 'GetAllUsers', params));
    },
    getUserByName: async (params) => {
        return trackPromise(post(baseURL + 'GetUserByName', params));
    },
    getNewsByDate: async (params) => {
        return trackPromise(post(baseURL + 'GetNewsByDate', params));
    },
    getPostsByDate: async (params) => {
        return trackPromise(post(baseURL + 'getPostsByDate', params));
    },
    getUserById: async (params) => {
        return trackPromise(post(baseURL + 'GetUserById', params));
    },
    removeUser: async (params) => {
        return trackPromise(post(baseURL + 'RemoveUser', params));
    },
    getAllRoles: async (params) => {
        return trackPromise(get(baseURL + 'GetAllRoles', params));
    },
    setUserRoles: async (params) => {
        return trackPromise(post(baseURL + 'SetUserRoles', params));
    },
    createRole: async (params) => {
        return trackPromise(post(baseURL + 'CreateRole', params));
    },
    editRole: async (params) => {
        return trackPromise(post(baseURL + 'EditRole', params));
    },
    deleteRole: async (params) => {
        return trackPromise(post(baseURL + 'DeleteRole', params));
    },
    getRSS: async (params) => {
        return trackPromise(get(baseURL + 'GetRSS', params));
    },
    banUser: async (params) => {
        return trackPromise(post(baseURL + 'BanUser', params));
    },
    createCategory: async (params) => {
        return trackPromise(post(baseURL + 'CreateCategory', params));
    },
    deleteCategory: async (params) => {
        return trackPromise(post(baseURL + 'DeleteCategory', params));
    },
}

export const get = (url) => {
    const promise = new Promise((resolve, reject) => {
        console.log('Sending GET: ' + url);
        resolve(axios.get(url)
            .then((response) => response.data)
            .catch((error) => {
                if (window.confirm(error + '\n\nMessage: ' + error.response.data.responseText + '\n\nRetry?')) {
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
                if (window.confirm(error + '\n\nMessage: ' + error.response.data.responseText + '\n\nRetry?')) {
                    // recursive call
                    return post(url, params);
                }
            }));
    });
    return promise;
}

export const postData = (url, params) => {
    const promise = new Promise((resolve, reject) => {
        console.log('Sending POST: ' + url + ' Form: ', params);
        resolve(axios.post(url, params)
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
