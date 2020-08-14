<template>
    <div>
        <navigation-bar/>
        <div class="search-page">
            <div class="search-header">Search Results:</div>
            <div class="results">
                <search-results v-bind:user-input="$route.params.currentSearch"/>
            </div>
        </div>
    </div>
</template>

<script>
import SearchResults from '../components/SearchResults'
import NavigationBar from '../components/NavigationBar'

export default {
    components: {
        SearchResults,
        NavigationBar
    },

}
</script>

<style scoped>
   .search-header {
        font-size: 4vh;
        text-align: center;
        padding-left: 10px;
        padding-top: 10px;
        color: rgba(192, 255, 200, 0.507);
        
    }
    .search-page {
        display: flex;
        flex-direction: column;
        margin-left: 25%;
        margin-right: 25%;
        

    }
</style>