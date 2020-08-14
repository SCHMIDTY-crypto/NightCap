<template>
  <div class="forum-page">
    <div class="sidebar">
      <div class="title-stuff">
        <div class="forum-title">{{forum.title}}</div>
        <b-button v-if="!showFavortied" size="sm" style="background-color: blue; border: 2px solid #ffff" class="link favorite" v-on:click="addToFavorites">FAVORITE</b-button> <b-button v-if="showFavortied" size="sm" style="background-color: green; border: 2px solid #ffff" class="link favorite" v-on:click="addToFavorites">FAVORITED</b-button>
      </div>
      <div class="forum-body">{{forum.body}} </div>
      <div class="moderator-container">
        <div class="moderator-header">Moderators: </div>
        <ul v-for="moderator in moderators" :key="moderator.userId">
          <li class="moderator-list">{{moderator.username}}</li>
        </ul> 
      </div>
    </div> 
    
    <div class="forum-container">
      <div class="posts-container">
        <posts />
      </div>
    </div>
  </div>
</template>

<script>
//import ForumList from '../components/ForumList'
import ForumService from '../services/ForumService'
import Posts from '../components/Posts'
import FavoriteService from '../services/FavoriteService'


export default {
    name: 'forum-details',
    props: ['id', 'title', 'body'],
    components: {
      Posts
    },
    data() {
      return {
        favoritedForums: [],
        showFavortied: false,
        forum: {
        forumId: "",
        title: "",
        body: "",
        dateCreated: "",
        posts: []
      },
      moderators: []
    }},
    methods: {
      setCurrentForum() {
        ForumService.getForum(this.$route.params.forumId).then(r => {
          this.forum = r.data;
        }).catch(e => {
          if (e.response) {
            alert(
                "something went wrong getting the forum." 
                
            )
          }
        })
      },
      addToFavorites() {
        const favoriteForum = {forumId: this.$route.params.forumId,
        userId: this.$store.state.user.userId}
        FavoriteService.forumFavorite(favoriteForum).then(
          response => {
            if (response.status === 200) {
              console.log("I think the database should get the forum");
              console.log(favoriteForum);
              this.showFavortied = true;
            }
            else {
              console.log("I don't think it worked.");
              console.log(favoriteForum);
            }
          },
        ).catch(error => {
          if (error.response && error.response.status === 400) {
            alert(
              "Couldnt add forum."
            );
          }
        });
      },
      getModerators() {
        ForumService.getModerators(this.$route.params.forumId).then(r => {
          this.moderators = r.data;
        }).catch(e => {
          if (e.response) {
            alert(
                "something went wrong getting the moderators." 
                
            )
          }
        })
      },
    },
    created() {
      this.setCurrentForum();
      this.getModerators();
      FavoriteService.getFavoriteForums(this.$store.state.user.userId).then(response => {
        this.favoritedForums = response.data.map(forum => forum.id);
        this.showFavortied = this.favoritedForums.includes(Number(this.$route.params.forumId));
      });
    }
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');
 
  .favorite {
    margin-left: 20px;
    margin-bottom: -4px;
    height: 40px;
  }
  .forum-page {
    display: flex;
    flex-direction: row;
  }
  .forum-title {
    font-size: 5vh;
    font-weight: 300;
  }
  .forum-title  {
    color: white;
    text-transform: uppercase;
    font-family: 'Quicksand', sans-serif;
    font-size: 8vh;
    text-shadow: 0 0 25px #ff005b;
    color: #c6e2ff;
    animation: neon .08s ease-in-out infinite alternate;
    -webkit-text-stroke: 1px #ccf4f7;
    text-align: center;
    animation: neon .08s ease-in-out infinite alternate;
    transform: rotate(-10deg);
    -webkit-text-stroke: 1px #ccf4f7;
    font-family: 'Dancing Script', cursive;
    
  }

  .forum-title:after {
    color: #ff005b;
    filter: blur(15px);
  }

  .forum-title:before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: #fe3a7f75;
    z-index: -2;
    opacity: .5;
    filter: blur(50px);
  }
  
  @keyframes neon {
    from {
      text-shadow:
      0 0 6px rgba(202,228,225,0.92),
      0 0 30px rgba(228, 202, 222, 0.42),
      0 0 12px #ff005b,
      0 0 21px #f11e68c9,
      0 0 34px #f11e68d7,
      0 0 54px #fd2671be;
    }
    to {
      text-shadow:
      0 0 6px rgba(202,228,225,0.98),
      0 0 30px rgba(228, 202, 222, 0.42),
      0 0 12px #ff005b,
      0 0 22px #e9276bc9,
      0 0 38px #c57893d7,
      0 0 60px #fd2671d5;
    }
  }
  .sidebar {
    font-size: 3vh;
    display: flex;
    flex-direction: column;
    align-content: center;
    text-align: center;
    align-items: center;
    position: fixed;
    background-color: rgba(0, 0, 0, 0.288);
    height: 100vh;
    width: 30vw;
  }
  .title-stuff {
    display: flex;
    flex-direction: row;

    padding-top: 20px;
    padding-bottom: 20px;
    padding-right: 50px;
    padding-left: 50px;
    width: 30vw;
  }
  .forum-title {
    margin: 20px;
  }
  .forum-body {
    border-top: 2px solid rgb(48, 37, 37);
    padding-top: 20px;
    padding-bottom: 20px;
    padding-right: 50px;
    padding-left: 50px;
    width: 30vw;
    font-size: 2vh;
    font-style: italic;

  }
  .moderator-container {
    border-top: 2px solid rgb(48, 37, 37);
    padding-top: 20px;
    padding-bottom: 20px;
    padding-right: 50px;
    padding-left: 50px;
    width: 30vw;
  }
  .moderator-list {
    list-style: none;
  }
  .forum-container {
    margin-left: 30vw;
    margin-right: 5vw;
    border-left: 2px solid rgb(48, 37, 37);
    border-right: 2px solid rgb(48, 37, 37);
  }
  .posts-container {
    margin-top: 50px; 
  }
</style>
 