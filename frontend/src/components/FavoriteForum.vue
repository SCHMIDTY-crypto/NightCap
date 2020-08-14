<template>
  <div class="body-container">
      <div class="activity-container" v-for="forum in favoriteForums" :key="forum.id">
            <router-link class="pushUpBtnTwo" :to="{name: 'forum', params: {forumId: forum.id} }"
            :title="forum.title" :body="forum.body" :id="forum.id">
            <h2>{{forum.title}}</h2>
            <p>{{forum.body}}</p></router-link>
        </div>
  </div>
</template>

<script>
import FavoriteService from '../services/FavoriteService'

export default {
    data() {
        return {
            favoriteForums: [],
        }
    },
    methods: {
        getFavoriteForums() {
            FavoriteService.getFavoriteForums(this.$store.state.user.userId).then(r => {
            this.favoriteForums = r.data;
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the forum." 
                        
                    )
                }
            });
        }
    },
    created() {
        this.getFavoriteForums();
    } 
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');

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
        justify-content: center;
        align-content: center;
        margin-left: 200px;
        margin-right: 200px;
        
        
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