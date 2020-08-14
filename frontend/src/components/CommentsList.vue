<template>
  <div class="comment-section">
    <b-container class="comments">
      <div v-for="comment in comments" :key="comment.commentId">
        <div class="author-date">   
          <div class="comment-author">by: {{comment.author}}</div> <div class="comment-date"> | {{comment.date | formatDate}}</div>
        </div>
        <div class="body">
          <div class="comment-body"><p>{{comment.body}}</p> </div>
        </div>
      </div>
    </b-container>      
    <b-modal class="add-comment" id="reply" title="Reply to comment" hide-footer>
      <add-comment /> 
    </b-modal>
  </div>
</template>

<script>
import AddComment from '../components/AddComment'
export default {
    name: "comments-list",
    props: ["comments"],
    components: {
      AddComment
    },
    data() {
      return {
        showReplyForm: false,
        isReply: false
      }
    }

}
</script>

<style scoped>
.comment-title {  
    padding-left: 10px;
    padding-top: 10px;
    font-size: 4vh;
    color: rgba(192, 255, 200, 0.507);
}

.author-date {
    display: flex;
    flex-direction: row;
    padding: 10px;
    padding-left: 10px;
    justify-content: center;
}
.comment-author {
    font-style: italic;
    padding-right: 8px;
}
.comment-date {
    color: grey;
}
.comments {
  margin-bottom: 10px;
}
.comment-section {
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;

}

.body {
  background-color: #26292cc9;
        border: 2px solid #00050a;
        padding: 10px;
        max-width: 30vw;
        margin-bottom: 10px;
}
</style>