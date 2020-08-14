
<template>
    <div>
        <div class="navbar-background" id="a" style="z-index:10">
            <b-navbar id="navbar" style="background-color: black; " fixed="top" class="navbar navbar-dark form-register" >
                <router-link :to=" {name: 'home'}">
                    <b-navbar-brand>
                        <div class="neon-wrapper">
                            <div class="neon-night">Night</div>
                            <div class="neon-cap">Cap</div>
                        </div>
                    </b-navbar-brand>
                </router-link>

                <b-container style="margin-right: 30px;" class="nav-center"> 
                    <div class="username" v-if='$store.state.user.username'>Hello, {{$store.state.user.username}}</div>
                    <div class="username" v-else><router-link :to=" {name: 'login'}">LOG IN</router-link></div>
                    <b-navbar-nav class="center">
                        <b-button size="sm" style="border: 2px solid #ffff" class="link links-container" :to=" {name: 'favorites'}" v-on:click.prevent="favorites">FAVORITES</b-button>
                        <b-button size="sm" style="border: 2px solid #ffff" class="link links-container" :to=" {name: 'forums'}" v-on:click.prevent="forums">FORUMS</b-button>
                            <div>
                                <b-button v-b-modal.forum size="sm" style="border: 2px solid #ffff" class="link links-container" href="#">CREATE FORUM</b-button>
                                <b-modal id="forum"  title="Create Forum" hide-footer >
                                    <b-container fluid >
                                        <b-row>
                                            <b-col>
                                                <add-forum-form /> 
                                            </b-col>
                                        </b-row>
                                    </b-container>
                                </b-modal>
                            </div>
                        
                        <b-nav-form class="left-space">
                            <b-form-input size="sm" class="links-container link mr-sm-2" 
                            placeholder="What's on your mind?"
                            v-model="userInput"
                            @keyup.enter="submit"
                            ></b-form-input>
                                <b-button style="border: 2px solid #ffff" size="sm" class="my-2 my-sm-0 link" type="submit" v-on:click.prevent="submit">SEARCH</b-button>
                        </b-nav-form>
                    </b-navbar-nav>
                </b-container>

                <b-navbar-nav class="ml-auto">
                    <b-container class="profile-container">
                        <b-navbar-brand class="profile left-space">
                            <img :src="$store.state.user.profilePicture" style="border: 2px solid #ffff" class="link icon" alt="icon">
                        </b-navbar-brand>
                        <b-dropdown text="OPTIONS" size="sm" style="border: 2px solid #ffff" class="my-2 my-sm-0 link options">
                            
                            <b-dropdown-item><router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;</b-dropdown-item>
                            <!-- <b-dropdown-item href="">Profile</b-dropdown-item> -->
                            <b-dropdown-item> <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></b-dropdown-item>
                        
                        </b-dropdown>
                    </b-container>
                </b-navbar-nav>
            </b-navbar>
            
        </div>
      <div style="margin-top: 175px;"> </div>
    </div>
</template> 

<script>
import AddForumForm from '../components/AddForumForm'

export default {
    name: "navigation",
    props: {

    },
    data() {
        return {
            userInput: "",
            bodyBgVariant: 'dark',
            bodyTextV: 'light',
            htv: 'light',
            hbv: 'dark',
            profilePicture: this.$store.state.user.profilePicture
        };
    },
    methods: {
        submit: function () {
            if (this.userInput != "")
            {
                this.$router.push('/search/' + this.userInput).catch(()=>{this.$router.go()});
            }
            else
            {
                this.makeToast("You need an item to search for!");
            }

            
        },
        favorites: function() {
            this.$router.push('/favoriteforum').catch(()=>{this.$router.go()});
        },
        getProfilePicture() {
            return this.profilePicture;
        },
        makeToast(toastMessage) {
            this.$bvToast.toast(`${toastMessage}`, {
            title: 'Notice',

            })
        }
    },
    components: {
        AddForumForm
    }
    
}
</script>
<style >
    .navbar-background {
        background-image: linear-gradient(235deg, #eeca52bb, #ff005b, #0080ff, #89ff00);
        height: 10px;
        width: 100vw;
        margin-left: -70px;
        position: fixed;
    }

  @import url('https://fonts.googleapis.com/css2?family=Dancing+Script:wght@700&display=swap');
  @import url('https://fonts.googleapis.com/css2?family=Vibur&display=swap');
    
    .links-container {
        margin-left: 10px;
    }
    .modal-content {
        background-color: dark;
    }
    .icon {
        border: 2px solid #b700ff;
        box-shadow: 0 0 5px #b700ff, 0 0 25px #b700ff;
        width: 100px;
        height: 100px;
    }
    .options {
        border: 2px solid #b700ff;
        box-shadow: 0 0 5px #b700ff, 0 0 25px #b700ff;
        width: 100px;
        margin-left: -16px;

    }
    .profile-container {
        display: flex;
        flex-direction: column;
        justify-content: center;
        margin-top: -20px;
    }

    .username {
        font-size: 4vh;
        margin-top: -30px;
        padding-bottom: 10px;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }
    .nav-center {
        display: flex;
        flex-direction: column;
    }
    .sign {
        min-height: 100%;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    .neon-wrapper {
        margin-left: 30px;
    }
    .neon-night {
        color: #c6e2ff;
        animation: neon .08s ease-in-out infinite alternate;
        transform: rotate(-10deg);
        font-size: 4rem;
        color: #fff;
        font-family: 'Vibur', cursive;
        -webkit-text-stroke: 1px #ccf4f7;
        text-align: center;
        text-shadow: 0 0 5px #03e9f4, 0 0 25px #03e9f4;
    }
    .neon-cap {
        color: #c6e2ff;
        animation: neon .08s ease-in-out infinite alternate;
        transform: rotate(-10deg);
        margin-left: 5px;
        margin-top: -52px;
        font-size: 5rem;
        color: #fff;
        -webkit-text-stroke: 1px #ccf4f7;
        font-family: 'Dancing Script', cursive;
        text-align: center;
    }
    @keyframes neon {
    from {
        text-shadow:
        0 0 6px rgba(202,228,225,0.92),
        0 0 30px rgba(202,228,225,0.34),
        0 0 12px #03e8f483,
        0 0 21px #1feaf5d5,
        0 0 34px #1cdde7e1,
        0 0 54px #1ceaf5ee;
    }
    to {
        text-shadow:
        0 0 6px rgba(202,228,225,0.98),
        0 0 30px rgba(202,228,225,0.42),
       0 0 12px #03e8f483,
        0 0 21px #0ddee9bd,
        0 0 34px #2ce6f0c4,
        0 0 54px #1ceaf5e3;
    }
}
</style>