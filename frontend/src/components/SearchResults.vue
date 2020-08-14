<template>
    <div class="body-container"> 
        <div class="search-header" v-if="forumSearchResults.length == 0">No Results Found</div>
        <div class="activity-container" v-else v-for="forum in forumSearchResults" :key="forum.id">
            <router-link class="pushUpBtnTwo" :to="{name: 'forum', params: {forumId: forum.id} }"
            :title="forum.title" :body="forum.body" :id="forum.id">
            <h2>{{forum.title}}</h2>
            <p>{{forum.body}}</p></router-link>
        </div>
    </div>
</template>

<script>
import searchService from '../services/SearchService'
export default {
    name: "search-service",
    components: {
    
    },
    props: {
        userInput: String
    },
    data() {
        return {
            forumSearchResults: []
        }
    },
    methods: {
        getUserSearch() {
            searchService.getUserSearch(this.userInput).then(result => {
                this.forumSearchResults = result.data;
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the forums."
                    )
                }
            })
        }
    },
    created() {
        this.getUserSearch();
    }
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');

    .body-container {
        
        height: 100vh;
    }
    a:hover {
        text-decoration: none;
    }
    .activity-container {
        font-family: 'Open Sans', sans-serif;
        color: white;
        display: flex;
        flex-direction: column;
        color: grey;
        text-align: center;
        margin-left: 200px;
        margin-right: 200px;
        
    }
    .search-header {
        font-size: 4vh;
        text-align: center;
        padding-left: 10px;
        padding-top: 10px;
        color: rgba(192, 255, 200, 0.507);
        
    }
  
    .pushUpBtnTwo {
        padding: 12px 24px;
        background-color: #000d1a00;
        color: white;
        border-radius: 6px;
        transition: transform 0.25s ease, box-shadow 0.25s ease, background-color 0.25s ease;
        box-shadow: 0 4px 6px rgba(50,50,93,.11), 0 1px 3px rgba(0,0,0,.08);
        border-bottom: 2px solid white;
    }

    .pushUpBtnTwo:hover {
        transform: translate3d(0px,-1px,0px);
        background-color: #0b20369d;
        box-shadow: 0 7px 14px rgba(50,50,93,.1), 0 3px 6px rgba(0,0,0,.08);
        text-decoration: none;
        color: rgba(255, 255, 0, 0.815);
        text-shadow: 0 0 5px rgba(255, 255, 0, 0.623), 0 0 25px rgba(255, 255, 0, 0.637);
        border-bottom: 2px solid rgba(255, 255, 0, 0.623);
    }
</style>