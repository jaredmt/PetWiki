<template>
  
  <Header />
  <router-view/>
  <Footer />
  
</template>


<script>
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'


export default{
  name:'App',
  components:{
    Header,
    Footer
  }
}

</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}



.container{
  display:flex;
  padding: 5px;
  max-width:1000px;
  justify-content: center;
  flex-direction: row;
  /* position:relative; */
  margin: 0 auto;
}
.col{
  display:flex;
  flex-direction: column;
  justify-content: center;
  margin: 5px;
  max-width: 500px;
  min-width:200px;
  flex-shrink: 1;
}

.row{
  flex-direction: row;
}


.arrow{
  text-align: center;
  font-size: 100px;
  align-content: center;
  color:#999;
  border-width: 2px;
  border-color: #999;
  /* border-style:solid; */
  display:flex;
  flex-direction: column;
  justify-content: center;
  margin: 5px 2px;
}

.left-arrow{
  box-shadow: -1px 1px 1px 1px #999;
}

.right-arrow{
  box-shadow: 1px 1px 1px 1px #999;
}

.arrow:hover{
  color:#111;
}

.left-arrow::after{
  content:"<"
}
.right-arrow::after{
  content:">"
}


@media screen and (max-width: 900px) {
  .container{
    flex-wrap:wrap-reverse;
  }
  .arrow{
    margin: auto;
    width:100%;
    max-width: 500px;
  }
}

</style>
