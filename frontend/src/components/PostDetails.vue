<template>
    <div class="page">
        <b-button size="sm" style="border: 2px solid #ffff" class="link links-container" :to=" {name: 'forum', params: {forumId: $route.params.forumId}}"><i class="arrow left"></i> BACK</b-button>
        <div class="post-details">
            <h2 class="post-title">{{post.title}}</h2>
            <div class="author-date">
                <div class="post-author">by: {{post.author }}  </div> <div class="post-date"> | {{post.date | formatDate}}</div>
            </div>

            <div class="body-image">
                <div class="post-body">{{post.body}}</div>
                <b-img class="post-image" id="post-image" v-if="post.imG_URL != '' && post.imG_URL != null " :src="post.imG_URL" fluid alt="This is a post's image" />
                
            </div>



            <h2 id="comment" class="text-center">Comments</h2>

            <b-button v-b-modal.comment style="margin: 10px;" >Add Comment</b-button>
            <b-modal id="comment" title="Add Comment" hide-footer size="lg">
                <add-comment /> 
            </b-modal>
            
            <b-container class="post-comment d-flex-coulmn" >
                <div id="comments">
                    <comment-list :comments="comments"/>
                </div>
            </b-container> 
        </div>
    </div>
    
</template>

<script>
import PostsService from '../services/PostsService'
import CommentList from '../components/CommentsList'
import VotesService from '../services/VotesService'
import AddComment from '../components/AddComment'

export default {
    name: "post-details",
    props: ['postId'],
    data() {
        return {
            post: {
                author: "",
                postId: "",
                forumId: "",
                title: "",
                userId: "",
                date: "",
                body: "",
                },   
            comments: [],
            votes: {
                downVotes: 6, 
                upVotes: 10
            }
        }
    },
    components: {
        CommentList,
        AddComment
    
    },
    methods: {
        getPost() {
            PostsService.getPosts(this.$route.params.forumId).then(r => {
                this.post = r.data.filter(f => f.id == this.postId)[0];
                
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the posts." 
                        
                    )
                }
            })
        },
        getComments() {
            PostsService.getComments(this.$route.params.postId).then(r => {
                this.comments = r.data;
            }).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the comments." 
                        
                    )
                }
            })
        },
        getVotes() {
            VotesService.getVotes(this.$route.params.postId).then(r => {
                this.votes = r.data.array.forEach(e => {
                    if (e.VoteType === 0) {
                        this.votes.downVotes++;
                    }else if (e.VoteType === 1) {
                        this.votes.upVotes++
                    }
                })}).catch(e => {
                if (e.response) {
                    alert(
                        "something went wrong getting the votes" 
                        
                    )
                }
            })
            
        },
    }, 
    created() {
        this.getPost();
        this.getComments();
    }

}
</script>

<style scoped>
.page {
    padding-top: 20px;
    margin-left: 200px;
    margin-right: 200px;
}
.post-details {
    text-align: center;
    
}
.post-title {  
    padding-left: 10px;
    padding-top: 10px;
    font-size: 4vh;
    color: rgba(192, 255, 200, 0.507);
}

.author-date {
    display: flex;
    flex-direction: row;
    padding-bottom: 20px;
    padding-left: 10px;
    justify-content: center;
}
.post-author {
    font-style: italic;
    padding-right: 8px;
}
.post-date {
    color: grey;
}
.post-image {
    justify-content: center;
    max-width: 30rem;
    max-height: 30rem;
    padding: 20px;
 
}

.body-image {
    background-color: #00050a2f;
    border: 2px solid #00050a;
}
.post-body{
    font-size: 2.5vh;
    padding: 20px;

}
.arrow {
  border: solid rgb(255, 255, 255);
  border-width: 0 3px 3px 0;
  display: inline-block;
  padding: 3px;
}
.left {
  transform: rotate(135deg);
  -webkit-transform: rotate(135deg);
}
.post-comment {
    background-color: #00050a7a;
    border: 2px solid #00050a;
    padding: 15px;
    display: flex;
    flex-direction: row;
    justify-content: center;
}

</style>