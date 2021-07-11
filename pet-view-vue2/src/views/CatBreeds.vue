<template>
    
    <Breed 
    api="http://localhost:56862/api/catbreeds" 
    title="Cat Breeds"
    />
</template>

<script>
import Breed from '../components/Breed.vue'
export default {
    name:'CatBreeds',
    components:{
        Breed
    }
}
</script>
