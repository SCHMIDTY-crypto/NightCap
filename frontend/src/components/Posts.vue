<template>
    <div>
        <b-container class="refine-add"> 
            <div class="refine">
                Sort by: <b-form-select style="width: 200px;" data-style="btn-dark" size="sm" v-bind:options="[{text: 'Popular', value: true},{text: 'Recent', value: false}]" 
                v-model="sortedPopular"></b-form-select>
            </div>
            <div class="add-post">
                <b-button v-b-modal.post size="sm" id="add-post-button" class="btn btn-submit" style="border: 2px solid #ffff">ADD NEW POST</b-button>
                <b-modal id="post" title="Create Post" hide-footer size="lg">
                    <create-post /> 
                </b-modal>                  
            </div>
        </b-container>

        <div v-for="post in selectedList" :key="post.postId" class="pushUpBtn post-container" :postId="post.postId">
            <router-link  :to="{name: 'post', params: {forumId: $route.params.forumId, postId: post.id}}">  
                <div class="post-container">        
                    <div class="post-title">                   
                        <h3 class="post-title">{{post.title}}</h3>
                    </div> 
                    <div class="author-date">
                        <div class="post-author">                   
                            <p class ="post-author">By {{post.author}}</p>
                        </div> 
                        <div class="post-date">                  
                            <p>{{post.date | formatDate}} </p>
                        </div>
                    </div> 
                    <div class="body-image">     
                        <div class="post-body">                   
                            <p >{{post.body}}</p>
                        </div>    
                        <div class="post-image">                   
                            <b-img style="max-width: 15rem; max-height: 10rem" id="post-image" v-if="post.imG_URL != '' && post.imG_URL != null " :src="post.imG_URL" fluid alt="This is a post's image" />
                        </div> 
                        
                    </div>
                </div>               
            </router-link>
        </div>
    </div>
</template>

<script>
import CreatePost from '../components/CreatePost'
import PostsService from '../services/PostsService'
// import VotesService from '../services/VotesService' 

export default {
    name: 'posts',
    components: {
        CreatePost
    },
    data() {
        return {
            sortedPopular: true,
            allPosts: [],
            newPost: {
                author: "",
                postId: "",
                forumId: "",
                title: "",
                userId: "",
                date: "",
                body: "",
                upVotes: 0,
                downVotes: 0
            }
        }
    },
    methods: {
        getPosts() {
            PostsService.getPosts(this.$route.params.forumId).then(r => {
                this.allPosts = r.data;
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the posts." 
                        
                    )
                }
            })
        },
        // getVotes() {
        //     VotesService.getVotes(this.post.postId)
        // }
    },
    created() {
        this.getPosts();
    },
    computed : {
        recentPosts() {
           return [...this.allPosts].sort((a, b) => {
                return new Date(b.date) - new Date(a.date);
            });
        
        },
        popularPosts() {
            return [...this.allPosts].sort((a, b) => {
                return b.upVotes - a.upVotes;
            });
        },
        selectedList() {
            if (this.sortedPopular)
            {
                return this.popularPosts;
            }
            else
            {
                return this.recentPosts;
            }
        }
    }
}
</script>

<style scoped>
 a:hover {
    text-decoration: none;
  }
@import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');
    .refine-add {
        display: flex;
        flex-direction: row;
        align-content: center;
        justify-content: center;
        padding-bottom: 10px;

    }
    #add-post-button {
        margin-left: 10px;
    }
    .post-container {
        display: flex;
        flex-direction: column;
        padding-right: 20px;
        padding-left: 20px;
        padding-bottom: 15px;
        color: white;

    }
    .post-title {
        color: rgba(192, 255, 200, 0.507);
    }
    .author-date {
        display: flex;
        flex-direction: row;

    }
    .post-author {
        margin-right: 10px;
    }
    .body-image {
        display: flex;
        flex-direction: row;
    }
    .post-body {
        width: 30vw;
        padding-right: 20px;
    }

   
</style>