<!--<template>
  <div>
    <form v-on:submit.prevent="addComment" class="newComment">
      <div>
        <label for="comment-body">Comment:</label>
        <b-form-textarea
          id="comment-body"
          v-model="comment.body"
          placeholder="Enter something..."
          rows="3"
          ></b-form-textarea>
      </div>
      <button type="submit" class="btn btn-submit">Submit</button>
    </form>
  </div>
</template>-->
<template>
  <div>
    <form v-on:submit.prevent="addPost" class="newPost">
      <div>
        <label class="post-header" for="title">Post Title: </label>
        <b-form-textarea id="post-title" v-model="post.title" placeholder="Enter something..." rows="1">

        </b-form-textarea>
      
        <b-form-textarea id="post-content" v-model="post.body" placeholder="Enter something..." rows="3">
        </b-form-textarea>
    

        <label class="post-img" for="img_url">Post Image URL: </label>
        <input type="text" name="img_url"  id="img_url" v-model="post.img_url">

      </div>
      <button type="submit" class="btn btn-submit">Submit</button>
    </form>
  </div>
</template>

<script>
import PostsService from '../services/PostsService'

export default {
    name: 'create-post',
    data() {
        return {
          
            post: {
      author: this.$store.state.user.username,
      forumId: this.$route.params.forumId,
      userId: this.$store.state.user.userId,
      title: "",
      img_url: "",
      body: "",
      upVotes: 0,
      downVotes: 0
        }
    }},
    methods: {
        addPost() {
          const newPost = {
            author: this.post.author,
            forumId: this.post.forumId,
            userId: this.post.userId,
            title: this.post.title,
            body: this.post.body,
            img_url: this.post.img_url,
            upVotes: 0,
            downVotes: 0
          }
            PostsService.addPost(newPost).then(r => 
            {
                if (r.status === 200) {
                this.makeToast("Post created!");
                this.$router.go();
              }
              else {
                PostsService.getPosts(this.$route.params.id);
                this.makeToast("Post may have been created, but something went wrong.");
                
              }
            }).catch(error => {
          if (error.response && error.response.status === 400) {
            this.makeToast("Couldn't add post. Sorry!");
          }
        });
        },
        makeToast(toastMessage) {
          this.$bvToast.toast(`${toastMessage}`, {
          title: 'Notice',

        })
    }

}}
</script>

<style>
</style>