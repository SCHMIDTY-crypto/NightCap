<template>
    <div>
        <navigation-bar/>
        <div class="forums-page">
            <div class="forum-header">Forums:</div>
            <div class="list-body">
                <forum-list/>
            </div>
        </div>
    </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar'
import ForumList from '../components/ForumList'

export default {
    components: {
        ForumList,
        NavigationBar
    },
}
</script>

<style scoped>
   
    .forum-header {
        font-size: 4vh;
        text-align: center;
        padding-left: 10px;
        padding-top: 10px;
        color: rgba(192, 255, 200, 0.507);
        
    }
    .forums-page {
        display: flex;
        flex-direction: column;
        margin-left: 25%;
        margin-right: 25%;
        

    }
</style> 