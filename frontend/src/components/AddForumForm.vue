<template>
  <div>
    <form v-on:submit.prevent="addForum" class="newForum">
      <div>
        <label for="title">Forum Name: </label>
        <b-form-textarea id="title" v-model="forum.title" placeholder="Enter something..." rows="1"></b-form-textarea>
      
        <label for="body">Forum Description: </label>
        <b-form-textarea id="body" v-model="forum.body" placeholder="Enter something..." rows="3"></b-form-textarea>
      </div>
      <b-button type="submit" size="sm" class="btn btn-submit" >Submit</b-button>
    </form>
  </div>
</template>

<script>
import forumService from '../services/ForumService';

export default {
  name: "add-forum-form",
  data() {
    return {  
      forum: {
      forumId: "",
      title: "",
      body: "",
      dateCreated: "",
      username: this.$store.state.user.username,
      userId: this.$store.state.user.userId,
      posts: []
    }
    } 
},
methods: {
  addForum() {
    const newForum = {title: this.forum.title, body: this.forum.body,
     userId: this.$store.state.user.userId, username: this.$store.state.user.username}
    forumService.addForum(newForum).then(
      response => {
        if (response.status === 200) {
          this.makeToast("Forum created!");  
          this.$router.push(`/forum/${response.data.id}`);
        }
        else {
          this.makeToast("Something went wrong, but your forum may have been created.");
          this.$router.go();
          
        }
      }
    ).catch(error => {
          if (error.response && error.response.status === 400) {
            this.makeToast("Forum couldn't be added. Sorry!");
          }else {
            this.makeToast("Forum couldn't be added. Sorry!");
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

<style scoped>

</style>