<template>
    <div id="nav">
    <router-link to="/">Home</router-link> |
    <!-- <router-link to="/about">About</router-link> |  -->
    <router-link to="/cat-breeds">Cat Breeds</router-link> | 
    <router-link to="/dog-breeds">Dog Breeds</router-link>
  </div>
</template>

<script>
export default {
    name:'Header'
}
</script>