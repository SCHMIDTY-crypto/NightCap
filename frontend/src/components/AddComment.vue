<template>
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
</template>

<script>
import PostsService from '../services/PostsService'

export default {
    name: 'add-comment',
    data() {
        return {
            comment: {
                author: this.$store.state.user.username,
                body:"",
                postId: this.$route.params.postId,
                userId: this.$store.state.user.userId,

        }
    }},
    methods: {
        addComment() {
          const newComment = {
                author:this.comment.author,
                body:this.comment.body,
                parentId: 1,
                postId: parseInt(this.comment.postId),
                userId: this.comment.userId
            
          }
            PostsService.addComment(newComment).then(r => 
            {
                if (r.status === 200 || r.status === 201) {
                  
                this.makeToast("Comment added!");
                this.$router.go();
        }
        else {
          PostsService.getComments(this.$route.params.id);
        
          
        }
        PostsService.getComments(this.$route.params.id);
            }).catch(error => {
          if (error.response && error.response.status === 400) {
            this.makeToast("Couldn't add comment. Sorry!");
          }
        });
        },
        makeToast(toastMessage) {
          this.$bvToast.toast(`${toastMessage}`, {
          title: 'Notice',

    })
  }
    }

}
</script>

<style>

</style>