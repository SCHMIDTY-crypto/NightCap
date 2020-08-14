<template>
  <div id="app">
    <router-view />
  </div>
</template>


<script>

export default {
}
</script>

<style>
  body {
    background-image: url('./assets/brick.png');
    background-attachment: fixed;
    
  }
  a:hover {
    text-decoration: none;
  }
  #app {
    color: #fff;
    padding-top: 10px;
    padding-right: 50px;
    padding-left: 50px;
    padding-bottom: 10px;background-image: radial-gradient(circle, rgba(255, 255, 255, 0.178), rgba(15, 19, 19, 0.452), rgba(0, 0, 0, 0.425));
    background-attachment: fixed;
    background-size: cover;
    height: 100%;
    font-weight: 300;
  }
</style> 