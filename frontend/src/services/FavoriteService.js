import axios from 'axios';

export default {
    forumFavorite(favoriteForum) {
        return axios.post('/favoriteforum', favoriteForum)
    },

    getFavoriteForums(userId) {
        return axios.get(`/favoriteforum/${userId}`)
    }
    
}