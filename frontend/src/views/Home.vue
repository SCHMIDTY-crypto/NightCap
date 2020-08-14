<template>
  <div class="home">
    <div class="container-fluid">
      <div class="behind-nav">
      <navigation-bar/>
      </div>
      <div class="row-body">
        <div class="col-md-8">
          <h3 class="text-center">
            Posts from {{currentActiveForum.title}}
          </h3>

          <div id="carousel">
            <post-carousel :posts="activeForumPosts"/>
          </div>
        </div>

        <div class="col-md-4">
          <h3 class="text-center">
            Most Active Forums
          </h3>
          <div class="row">
            <div class="col-md-12 active-forums">
              <active-forums :forums="this.forums"/> 
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar'
import PostCarousel from '../components/PostCarousel'
import ActiveForums from '../components/ActiveForums'
import ForumService from '../services/ForumService'
import PostsService from '../services/PostsService'


export default {
  name: 'home',
  components: {
    NavigationBar,
    PostCarousel,
    ActiveForums,
  },
  data() {
    return {
      currentActiveForum: {},
      forums: [],
      activeForumPosts: [],
      id: ''
    }
  },
  methods: {
    userForumSearch(input) {
      this.childData= input;
    },
    getActiveForum() {
    ForumService.getActiveForums().then(r => {
        this.forums = r.data;
        this.currentActiveForum = r.data[0];
        this.id = this.currentActiveForum.id;
        this.$store.commit("GET_ACTIVE_FORUM", r.data[0]);
        this.getPosts();
    }).catch(e => {
        if (e.response) {
            alert(
                "something went wrong getting the forums."
            )
        }
    })
  },
  getPosts() {
    PostsService.getPosts(this.id).then(r => {
        this.activeForumPosts = r.data;
    }).catch(e => {
        if (e.response) {
            console.log("something went wrong getting the active forum's posts."); 

        }
    })
  }
  },
  created() {
    this.getActiveForum();
    
  },
};
</script>

<style scoped>


  @import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');
  .row-body {
    display: flex;
    justify-content: center;
    align-content: center;
    margin-left: 100px;
    margin-right: 100px;
    padding-top: 20px;
  }
  h3 {
    font-style: italic;
    color: grey;
    padding-bottom: 10px;
    
  }
  .activity-container {
    font-family: 'Open Sans', sans-serif;
    color: white;
    display: flex;
    flex-direction: column;
    color: white;
    text-align: center;

  }
  .body-container {
    padding-bottom: 10px;
      
  }
  
</style>