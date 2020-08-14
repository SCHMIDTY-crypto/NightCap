import axios from 'axios';

export default {

  addForum(forum) {
    return axios.post('/forum', forum)
  },

  getForums() {
    return axios.get('/forum')
  },

  getForum(forumId) {
    return axios.get(`/forum/${forumId}`)
  },

  getModerators(forumId) {
    return axios.get(`/forum/${forumId}/moderators`)
  },

  getActiveForums() {
    return axios.get('/forum/active')
  }

}
// //{
//   "userId": 4,
//   "username": "josiah",
//   "title": "Angry Birds",
//   "body": "This game is a classic casual game",

// }