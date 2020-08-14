import axios from 'axios';

export default {
    getUserSearch(userInput) {
        return axios.get(`/forum/search?searchString=${userInput}`, userInput)
    }
}