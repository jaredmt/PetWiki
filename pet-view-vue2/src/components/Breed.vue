<template>
    <h1>{{title}}</h1>

    <div class="container">
        <div class="arrow left-arrow" @click="setBreed"></div>
        

        <div class="col">
            <div class="row"><h2>{{breedData.breed}}</h2></div>
            <div class="row"><p>{{breedData.description}}</p></div>
        </div>
        
        <div class="col">
            <img :src="breedData.imageURL" :alt="breedData.breed">
        </div>

        <div class="arrow right-arrow" @click="setBreed"></div>
    </div>
    

</template>

<script>


export default {
    name:'Breed',
    props:{
        api:String,
        title:String
    },
    data(){
        return {
            breedData:{
                breed:"",
                description:"",
                imageURL:""
            }
        }
    },
    methods:{
        async getBreed(){
            const res = await fetch(this.api)
            const data = await res.json()
            return data
        },
        async setBreed(){
            const data = await this.getBreed()
            this.breedData=data;
        }
    },
    async created(){
        await this.setBreed()
    }
}
</script>