import axios from 'axios';

export default {

  getPosts(forumId) {
    return axios.get(`/forum/${forumId}/posts`)
  },

  addPost(post) {
    return axios.post('post', post)
  },

  getComments(postId) {
    return axios.get(`post/${postId}/comments`)
  },

  addComment(comment) {
    return axios.post('/comment', comment)
  }

}