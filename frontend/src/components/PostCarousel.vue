<template>
  <div>
    <b-carousel  id="carousel-1" :interval="4000" controls indicators img-width="100" img-height="50"
      style="text-shadow: 1px 1px 2px #333;">
    <div v-for="post in fivePosts" :key="post.id">
        <b-carousel-slide caption:=post.title img-blank class="body-container"  >
            <b-container fluid class="activity-container ">
                    
                <router-link :to="{name: 'post', params: {forumId: $route.params.forumId, postId: post.id}}"
                class="">
                    <div class="carousel-post">
                        <div class="post-title">
                            <h2>{{post.title}}</h2>
                        </div>
                        <div class="author-date">
                            <div class="post-author">By: {{post.author}}</div> <div class="post-date">{{post.date | formatDate}}</div>
                        </div>


                        <b-img id="post-image" style="max-height: 30vh; " v-if="post.imG_URL != '' && post.imG_URL != null " :src="post.imG_URL" fluid alt="This is a post's image">
                        </b-img>
                        <b-img id="transparent image" v-bind="mainProps" style="max-width: 15rem; max-height: 30vh" v-else  fluid alt="This is a post's image">
                        </b-img>
                    </div>
                    
                </router-link>
            </b-container>
        </b-carousel-slide>
      </div>
      

    </b-carousel>
    <br><br><br>
  </div>
</template>

<script>
//import PostsService from '../services/PostsService'
export default {
    props: ['posts'],
    data() {
        return {
            sortedPopular: true,
            //posts: [],
            mainProps: { blank: true, width: 100, height: 100, class: 'm1' },
            limit: 5
        }
    },
    methods: {
        // getPosts() {
        //     PostsService.getPosts(this.forumId).then(r => {
        //         this.posts = r.data;
        //     }).catch(e => {
        //         if (e.response) {
        //             alert(
        //                 "something went wrong getting the active forum's posts." 
                        
        //             )
        //         }
        //     })
        // }
    },
    computed: {
        fivePosts() {
            return this.limit ? this.posts.slice(0, this.limit) : this.posts
        }
    },
    created() {
        //this.getPosts();
    },

}
</script>

<style scoped>
    .body-container {
        background-image: grey;
        color: white;
    }
    .post-image {
        box-shadow: black;
    }
    a:hover {
        text-decoration: none;
    }

</style>