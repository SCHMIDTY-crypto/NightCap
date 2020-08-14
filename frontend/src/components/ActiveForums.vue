<template>
    <div class="body-container">
        <div class="activity-container" v-for="forum in forums" :key="forum.id">
            <router-link class="pushUpBtn" :to="{name: 'forum', params: {forumId: forum.id} }"
            :title="forum.title" :body="forum.body" :id="forum.id">
            <h2>{{forum.title}}</h2>
            <p id="forum-body">{{forum.body}}</p></router-link>
        </div>
    </div>
</template>

<script>
//import forumService from '../services/ForumService'


export default {
    name: 'active-forums',
    components: {
    
    },
    props: ['forums'],
    data() {
        return {

        }
    },
    methods: {},
    computed: {},
    created() {

    }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');
    .activity-container {
        font-family: 'Open Sans', sans-serif;
        color: white;
        display: flex;
        flex-direction: column;
        color: grey;
        text-align: center;
        
    }
  
    .pushUpBtn {
        padding: 12px 24px;
        background-color: #000d1a00;
        color: white;
        border-radius: 6px;
        transition: transform 0.25s ease, box-shadow 0.25s ease, background-color 0.25s ease;
        box-shadow: 0 4px 6px rgba(50,50,93,.11), 0 1px 3px rgba(0,0,0,.08);
        border-bottom: 2px solid white;
    }

    .pushUpBtn:hover {
        transform: translate3d(0px,-1px,0px);
        background-color: #0b20369d;
        box-shadow: 0 7px 14px rgba(50,50,93,.1), 0 3px 6px rgba(0,0,0,.08);
        text-decoration: none;
        color: rgba(255, 255, 0, 0.815);
        text-shadow: 0 0 5px rgba(255, 255, 0, 0.623), 0 0 25px rgba(255, 255, 0, 0.637);
        border-bottom: 2px solid rgba(255, 255, 0, 0.623);
    }
</style>