<template>
    <Breed 
    api="http://localhost:56862/api/dogbreeds" 
    title="Dog Breeds"
    />
</template>

<script>
import Breed from '../components/Breed.vue'
export default {
    name:'DogBreeds',
    components:{
        Breed
    }
}
</script>