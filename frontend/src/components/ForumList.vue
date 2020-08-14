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
import forumService from '../services/ForumService'


export default {
    name: 'forum-list',
    components: {
    
    },
    data() {
        return {
            forums: []
        }
    },
    methods: {
        getForums() {
            forumService.getForums().then(r => {
                this.forums = r.data;
               // this.getForums();
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the forums."
                    )
                }
            })
        },


    },
    computed: {},
    created() {
        this.getForums();
    }
}
</script>

<style scoped>
  
</style>