import axios from 'axios';

export default {

  getVotes(postId) {
    return axios.get(`/post/${postId}/votes`)
  },
  postVote(postId) {
    return axios.post(`/post/${postId}/votes`)
  }

}