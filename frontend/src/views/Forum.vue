<template>
  <div class="Forum">
      <navigation-bar/>
      <div>
        <div><forum-details /></div>
      </div>
    
  </div>
</template>

<script>
import forumDetails from '../components/ForumDetails'
import NavigationBar from '../components/NavigationBar'

export default {
  name: "forum",
  components: {
      NavigationBar,
      forumDetails,
  },
  data() {
    return {
      showAddPost: false
    }
  }
}
</script>

<style>

</style>