<template>

<div v-if="house === null">
    laden
</div>

<div v-else>    
    <div class="container">

        <div class="card">
            <div>
                <img class="picture" :src="house.image"/>
            </div>
            
            <div class="my1">
                <div class="StreetEditDelete">
                    <div>
                        {{ house.location.street }}
                    </div>

                    <div>
                        <button class="button-62" v-if="house.madeByMe" @click="goToHouseEdit(house)">edit</button>
                        <button class="button-62" v-if="house.madeByMe" @click="deleteHouse(house)">Delete</button>
                    </div>

                </div>

                <div class="ZipCity">
                    <i class="fa-solid fa-location-dot"></i>
                    {{ house.location.zip }}
                    {{ house.location.city }}
                </div>

                <div class="PriceSizeHistory">
                    <div> 
                        <i class="fas fa-euro-sign"></i>
                        {{ house.price }}
                    </div>
                    <div> 
                        <i class="fas fa-vector-square"></i>
                        {{ house.size }}
                    </div>
                    <div> 
                        <i class="fa-solid fa-hammer"></i>
                        {{ house.constructionYear }}
                    </div>
                </div>

                <div class="rooms" >
                    <div> 
                        <i class="fas fa-bed"></i>
                        {{ house.rooms.bedrooms }}
                    </div>
                    
                    <div> 
                        <i class="fas fa-bath"></i>
                        {{ house.rooms.bathrooms }}
                    </div>
                    <div>
                        <div v-if="house.hasGarage === false">
                            <i class="fa-solid fa-warehouse"></i>
                            no
                        </div>
                        <div v-else>
                            <i class="fa-solid fa-warehouse"></i>
                            yes
                        </div>
                    </div>
                </div>

                <div class="description"> 
                    {{ house.description }}
                </div>
            </div>
        </div>
    </div>
</div>

</template>

<script>


export default {
    data () {
        return {
            house: null,
        }
    },
    mounted () {
        fetch('https://api.intern.d-tt.nl/api/houses', {//get
            headers: {
                'Content-Type':'application/json',
                'X-Api-Key':'73e_ERkfjLsFYG5vc81KP4TonQJSH6wr',
            }
        })
        .then(response => response.json())
        .then(data => this.houses = data)
        .then(() => { 
            let i = 0
            while(i < this.houses.length){
                let house = this.houses[i]
                let houseIdString = house.id.toString()

                i++;
                if(houseIdString === this.$route.params.id){
                    this.house = house
                }
            }
        })
    },

    methods: {
        
        goToHouseEdit(house){
            this.$router.push('/details/edit/' + this.house.id)
            console.log('goToHouseEdit', house)
        },

        deleteHouse(house){
            
            let confirmAction = confirm("Are you sure you want to delete?")
            
            if (confirmAction) {

                alert("Delete successfully executed");
                fetch("https://api.intern.d-tt.nl/api/houses/"+ house.id,{
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'X-Api-Key':'73e_ERkfjLsFYG5vc81KP4TonQJSH6wr',
                    }
                })
                .then(response => response.text())
                .then(result => console.log(result))
                .catch(error => console.log('error', error));
                this.house.splice;
                console.log(house)
                this.$router.push('/')
            }
        }
    }
}

</script>

<style scoped>
.StreetEditDelete{
    font-weight: bold;
    font-size:40px;
    margin:1rem;
    justify-content: space-between;
    display: flex;

}
.ZipCity {
    margin: 1rem;
}
.PriceSizeHistory {
    display: flex;
    margin:1rem;
    flex-direction: row;
    gap: 10px;
}
.rooms {
    display:flex;
    margin: 1rem;
    flex-direction: row;
    gap: 10px;
}
.description {
    display:flex;
    margin: 1rem;

}
.container {
    justify-content: center;
    flex-direction: column;
}

.card {
    width: 750px;
    margin: 0 auto;
    margin-top:1rem;
    overflow: auto;
    height: 100%;
    background-color: white;
}

.picture {
  width:750px;
  height:500px;
  border-radius: 5px;
  justify-content: center;
}

.button-62 {
  background: linear-gradient(to bottom right, rgb(235,84,64), rgba(225,84,64));
  border: 0;
  border-radius: 12px;
  color: #2b2e2e;
  cursor: pointer;
  display: inline-block;
  font-family: Open Sans, Montserrat;
  font-size: 13px;
  font-weight: 500;
  line-height: 2.5;
  outline: transparent;
  padding: 0 1rem;
  text-align: center;
  text-decoration: none;
  transition: box-shadow .2s ease-in-out;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
}

.button-62:not([disabled]):focus {
  box-shadow: 0 0 .25rem rgba(0, 0, 0, 0.5), -.125rem -.125rem 1rem rgba(239, 71, 101, 0.5), .125rem .125rem 1rem rgba(255, 154, 90, 0.5);
}

.button-62:not([disabled]):hover {
  box-shadow: 0 0 .25rem rgba(0, 0, 0, 0.5), -.125rem -.125rem 1rem rgba(239, 71, 101, 0.5), .125rem .125rem 1rem rgba(255, 154, 90, 0.5);
}

/* SortBy */

select {
  -webkit-appearance:none;
  -moz-appearance:none;
  -ms-appearance:none;
  appearance:none;
  outline:0;
  box-shadow:none;
  border:0!important;
  background: #EB5440;
  background-image: none;
  flex: 1;
  padding: 0 .5em;
  color:#2b2e2e;
  cursor:pointer;
  font-size: 1em;
  font-family: 'Open Sans', sans-serif;
  display: flex;
  justify-content: flex-end; 
}
select::-ms-expand {
   display: none;
}
.select {
   position: relative;
   display: flex;
   width: 20em;
   height: 3em;
   line-height: 3;
   background: #EB5440;
   overflow: hidden;
   border-radius: .25em;
}
.select::after {
   content: '\25BC';
   position: absolute;
   top: 0;
   right: 0;
   padding: 0 1em;
   background: #2b2e2e;
   cursor:pointer;
   pointer-events:none;
   transition:.25s all ease;
}
.select:hover::after {
   color: #EB5440;
}

</style>