<template>
  <div class="main">
    <router-link :to=" {name: 'home'}">
      <div id="neon-wrapper" class="text-left">
          <div class="neon-night">Night</div>
          <div class="neon-cap">Cap</div>
      </div>
    </router-link>
    <div id="register" class="text-center">
      <form class="form-register" @submit.prevent="register">
        <h1 class="h3 mb-3 font-weight-normal">register</h1>
        <div class="alert alert-danger" role="alert" v-if="registrationErrors">
          {{ registrationErrorMsg }}
        </div>
        <label for="username" class="sr-only">Username</label>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />
        <label for="password" class="sr-only">Password</label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm"
          v-model="user.confirmPassword"
          required
        />
        <label for="url" class="sr-only">Profile Picture</label>
        <input
          type="url"
          id="profilePicture"
          class="form-control"
          placeholder="Picture URL"
          v-model="user.profilePicture"
        />
        <router-link :to="{ name: 'login' }">Have an account?</router-link>
        <button class="btn btn-lg btn-primary btn-block" type="submit">
          Create
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
        profilePicture: ''
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>


  .form-register {
    width: 400px;
    padding: 40px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
    display: block;
    align-items: center;
    background: #000d1af1;
  }

  .text-center {
    width: 400px;
    padding-right: 200px;
    padding-top: 525px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
    display: block;
    align-items: center;
    background: #000d1a;
  }

  .text-center:before {
    content: '';
    position: absolute;
    top: -2px;
    left: -2px;
    right: -2px;
    bottom: -2px;
    background: white;
    z-index: -1;
  }

  .text-center:after {
    content: '';
    position: absolute;
    top: -2px;
    left: -2px;
    right: -2px;
    bottom: -2px;
    background: white;
    z-index: -2;
    filter: blur(40px);
  }

  .text-center:before,
  .text-center:after {
    background: linear-gradient(235deg, #eeca52bb, #ff005b, #0080ff, #89ff00);
    
  }
  @keyframes change {
    0%{
      background-position: 0 50%;
    }
    50%{
      background-position: 100% 50%;
    }
    100%{
      background-position: 0 50%;
    }
  }
  .form-register h1 {
    color: white;
    text-transform: uppercase;
    font-family: 'Quicksand', sans-serif;
    margin: 0;
    font-size: 3em;
    text-shadow: 0 0 25px #ff005b;
    position: relative;
    letter-spacing: 8px;
    
  }

  .form-register h1:after {
    content: attr(data-text);
    top: 0;
    left: 0;
    padding: 0 60px;
    position: absolute;
    z-index: -1;
    color: #ff005b;
    filter: blur(15px);
  }

  .form-register h1:before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: #fe3a80;
    z-index: -2;
    opacity: .5;
    filter: blur(40px);
  }

  .form-register input[type = "text"], .form-register inupt[type = "password"], .form-register input[type = "url"] {
    border: 0;
    background: none;
    display: block;
    margin: 20px auto;
    text-align: center;
    border: 2px solid #0080ff;
    padding: 14px 10px;
    width: 200px;
    outline: none;
    color: white;
    border-radius: 25px;
    transition: 0.25;
    box-shadow: 0 0 5px #03e9f4, 0 0 25px #03e9f4;
    letter-spacing: 4px;

  }

  .form-register input[type = "text"]:focus, .form-register input[type = "password"], .form-register input[type = "url"] {
    border: 0;
    background: none;
    display: block;
    margin: 20px auto;
    text-align: center;
    border: 2px solid #0080ff;
    padding: 14px 10px;
    width: 200px;
    outline: none;
    color: white;
    border-radius: 25px;
    transition: 0.25;
    box-shadow: 0 0 5px #03e9f4, 0 0 25px #03e9f4;
    letter-spacing: 4px;
  }

  .form-register button[type = "submit"] {
    border: 2px solid #2ecc71;
    background: none;
    display: block;
    margin: 25px auto;
    text-align: center;
    padding: 14px 40px;
    outline: none;
    color: white;
    letter-spacing: 4px;
    border-radius: 25px;
    transition: 0.25;
    cursor: pointer;
    box-shadow: 0 0 5px #2ecc71, 0 0 25px #2ecc71;
  }
  

  h1 {
    color: #c6e2ff;
    animation: neon .08s ease-in-out infinite alternate;
    -webkit-text-stroke: 1px #ccf4f7;
    text-align: center;
    text-transform: uppercase;
    margin: 0;
    font-size: 3em;
    text-shadow: 0 0 25px #ff005b;
    position: relative;
    letter-spacing: 8px;
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

  #neon-wrapper {
    margin-left: -63%;
  }
  a:hover {
    text-decoration: none;
  }

</style>


