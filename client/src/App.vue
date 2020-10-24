<template>
    <div id="app">
        <navigation></navigation>
        <router-view></router-view>
    </div>
</template>

<script>
import Navigation from "./components/layout/Navigation";

export default {
    name: "App",
    components: {
        navigation: Navigation,
    },

    data() {
        return {};
    },
};
</script>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}

@import "~bootstrap/dist/css/bootstrap.css";
@import "./css/site.css";
</style>
