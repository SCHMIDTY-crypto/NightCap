<template>
  <div>
      <navigation-bar/>
      <div>
          <post-details :postId="$route.params.postId"/>
      </div>

  </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar'
import PostDetails from '../components/PostDetails'

export default {
    components: {
        PostDetails,
        NavigationBar,
        
    }

}
</script>

<style>
</style>