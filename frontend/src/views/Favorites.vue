<template>
    <div class="favorites">
        <navigation-bar/>
        <div class="favorites-page">
            <div class="favorites-header">Favorites:</div>
            <div class="list-body">
                <favorite-forum />
            </div>
        </div>
    </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar'
import FavoriteForum from '../components/FavoriteForum'

export default {
    components: {
        FavoriteForum,
        NavigationBar
    },
}
</script>

<style scoped>
    .favorites {
        height: 100vh;
    }
  .favorites-header {
        font-size: 4vh;
        text-align: center;
        padding-left: 10px;
        padding-top: 10px;
        color: rgba(192, 255, 200, 0.507);
        
    }
    .favorites-page {
        display: flex;
        flex-direction: column;
        margin-left: 25%;
        margin-right: 25%;
        

    }
</style> 