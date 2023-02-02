<template>
<div class="flex-container">

  <div v-if="loading === false">
    
    <div class="headersort">
      <div class="SearchAndResult">
        <form action="" class="search-bar">
          <input type="search" v-model="searchValue" placeholder=" Search houses" name="search" pattern=".*\S.*" required>
          <button class="search-btn" type="submit"></button>
        </form>
        
        <div class="result">
          <i v-if="(searchHouses.length === 1)">1 result found</i>
          <i v-else-if="(searchHouses.length === 0)">no results found</i>
          <i v-else-if="(searchHouses.length === 10)">10 results available</i>
          <i v-else>{{searchHouses.length}} results found</i>
        </div>
      </div>
      
      <div class="select">
        <select v-model="sortby" name="format" id="format">
          <option value="" disabled hidden>Sort By</option>
          <option value="price">price</option>
          <option value="size">size</option>
        </select>
      </div>
    </div>

    <div class="buttonheader">
      <div></div>
      <div class="btn-card">
        <button class="button-62" @click="GoToHouseAdd" role="button">Create New</button>
      </div>
    </div>
    
    <section class="houses" >
      <div class="container flex">
        <div v-for="(house) in searchHouses" :key="house">
          
          <div class="card" @click="goToHouseDetails(house)">
            <div> 
              <img class="picture" :src="house.image"/>
            </div> 
            <div class="my-1">
              <div class="street"> 
                <i class="fas fa-road"></i>
                {{house.location.street}}
              </div>
              <div class="price">
                <i class="fas fa-euro-sign"></i>
                {{house.price}}
              </div>
              <div class="city"> 
                <i class="fas fa-city"></i>
                {{house.location.zip}}
                {{house.location.city}}
              </div>
              <div class="my-2">
                <div class="bathrooms">
                  <i class="fas fa-bath"></i>
                  {{house.rooms.bathrooms}}
                </div>
                <div class="bedrooms">
                  <i class="fas fa-bed"></i>
                  {{house.rooms.bedrooms}}
                </div>
                <div class="size">
                  <i class="fas fa-vector-square"></i>
                  {{house.size}}m2
               </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  
  <div class="fa-2x" v-else>
    <i class="fa-solid fa-spinner fa-spin-pulse"></i>
    <span>loading houses</span>
  </div>

</div>

</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },

  data () {
    return {
      houses: [],//get houses
      loading : true,
      searchValue: '',
      sortby: '',
    }
  },

  computed: {
    FilteredHouses() {
      if(this.searchValue.trim().length > 0) {
        return this.houses.filter((house) => house.location.street.toLowerCase().includes(this.searchValue.toLowerCase().trim()) ||
        house.location.city.toLowerCase().includes(this.searchValue.toLowerCase().trim()) ||
        house.location.zip.toLowerCase().includes(this.searchValue.toLowerCase().trim())
        )
      }
      return this.houses
      
    },
    searchHouses() {
      return [...this.FilteredHouses].sort((a, b) =>
        a[this.sortby] - (b[this.sortby])
      );
    },
  },


  mounted () {
    fetch('https://api.intern.d-tt.nl/api/houses', {
      headers: {
        'Content-Type': 'application/json',
        'X-Api-Key':'73e_ERkfjLsFYG5vc81KP4TonQJSH6wr'
      }
    })
    .then(response => response.json())
    .then(data => this.houses = data)
    .then(() => console.log(this.houses))
    .finally(() => this.loading = false)
  },
  methods: {
    goToHouseDetails(house){
      this.$router.push('/details/' + house.id)
      console.log(house)
    },
    GoToHouseAdd(house){
      this.$router.push('/add/')
      console.log(house)
    }
  }
}

</script>


<style scoped>

/* @import '/style.css' */

/* .flex-container{
  background-color:#F6F6F6;

} */
.headersort {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 20px;
}
.buttonheader {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 20px;
}
.btn {
  font-size: 2.0rem;
  text-decoration: none;
  color: rgb(28, 26, 26);
  background: linear-gradient(90deg,rgb(235,84,64)0%, rgb(236, 188, 169)100%);
  border-radius: 9.5px;
  margin-top: 15px;
}

.btn-card {
  margin-top: 15px;
}
.card {
  background-color: #fff;
  color: #333;
  border-radius: 10px;
  box-shadow: 0 3px 10px rgba(225,84,64);
  padding: 20px;
  margin: 10px;
  width: 1010px;
}

.houses .card {
  margin: 18px 10px 40px;
  transition: transform 0.2s ease-in;
  
}
.houses .card h4 {
  font-size: 20px;
  margin-bottom: 10px;
}
.houses .card:hover {
  transform: translateY(-15px);
}
.container {
  max-width: 1100px;
  margin: 0 auto;
  overflow: auto;
  padding: 0 40px;
  
}
.flex {
  height: 100%;
  flex-direction: column;
}

/* houses card */
.card {
  display: flex;
  justify-content: flex-start;
  font-family:Open Sans, Montserrat;
}
.picture {
  width:100px;
  height:80px;
  border-radius: 5px;
  margin-right: 10px
}

.size {
  align-items: flex-end;
}
.street {
  font-weight: bold;
  font-size: large;
}
.city {
  color:#C3C3C3
}
.my-1 {
  flex-direction: row-reverse;
  align-items: flex-end;

}
.my-2 {
  display: flex;
  align-items: flex-end;
}
/* create button */

button, input {
	font: 0.7505em Open Sans, Montserrat;
	line-height: 1.5em;
}
input {
	color: #171717;
}
.search-bar {
	display: flex;

}
.search-bar input, .search-btn, .search-btn:before, .search-btn:after {
	transition: all 0.25s ease-out;
}
.search-bar input, .search-btn {
	width: 3em;
	height: 3em;
}
.search-bar input:invalid:not(:focus),
.search-btn {
	cursor: pointer;
}
.search-bar, .search-bar input:focus, .search-bar input:valid  {
	width: 100%;
}
.search-bar input:focus, .search-bar input:not(:focus) + .search-btn:focus {
	outline: transparent;
}
.search-bar {
	max-width: 30em;
}
.search-bar input {
	background: transparent;
	border-radius: 1.5em;
	box-shadow: 0 0 0 0.4em #171717 inset;
	padding: 0.75em;
	transform: translate(0.5em,0.5em) scale(0.5);
	transform-origin: 100% 0;
	-webkit-appearance: none;
	-moz-appearance: none;
	appearance: none;
}
.search-bar input::-webkit-search-decoration {
	-webkit-appearance: none;
}
.search-bar input:focus,
.search-bar input:valid {
	background: #fff;
	border-radius: 0.375em 0 0 0.375em;
	box-shadow: 0 0 0 0.1em #d9d9d9 inset;
	transform: scale(1);
}
.search-btn {
	background: #171717;
	border-radius: 0 0.75em 0.75em 0 / 0 1.5em 1.5em 0;
	padding: 0.75em;
	position: relative;
	transform: translate(0.25em,0.25em) rotate(45deg) scale(0.25,0.125);
	transform-origin: 0 50%;
}
.search-btn:before, .search-btn:after {
	content: "";
	display: block;
	opacity: 0;
	position: absolute;
}
.search-btn:before {
	border-radius: 50%;
	box-shadow: 0 0 0 0.2em #f1f1f1 inset;
	top: 0.75em;
	left: 0.75em;
	width: 1.2em;
	height: 1.2em;
}
.search-btn:after {
	background: #f1f1f1;
	border-radius: 0 0.25em 0.25em 0;
	top: 51%;
	left: 51%;
	width: 0.75em;
	height: 0.25em;
	transform: translate(0.2em,0) rotate(45deg);
	transform-origin: 0 50%;
}
.search-btn span {
	display: inline-block;
	overflow: hidden;
	width: 10px;
	height: 10px;
}

/* Active state */
.search-bar input:focus + .search-btn, .search-bar input:valid + .search-btn {
	background: rgb(235,84,64);
	border-radius: 0 0.375em 0.375em 0;
	transform: scale(1);
}
.search-bar input:focus + .search-btn:before, 
.search-bar input:focus + .search-btn:after,
.search-bar input:valid + .search-btn:before, 
.search-bar input:valid + .search-btn:after {
	opacity: 1;
}
.search-bar input:focus + .search-btn:hover,
.search-bar input:valid + .search-btn:hover,
.search-bar input:valid:not(:focus) + .search-btn:focus {
	background: #0c48db;
}
.search-bar input:focus + .search-btn:active,
.search-bar input:valid + .search-btn:active {
	transform: translateY(1px);
}

@media screen and (prefers-color-scheme: dark) {
	body, input {
		color: #f1f1f1;
	}
	body {
		background: #171717;
	}
	.search-bar input {
		box-shadow: 0 0 0 0.4em #f1f1f1 inset;
	}
	.search-bar input:focus,
	.search-bar input:valid {
		background: #3d3d3d;
		box-shadow: 0 0 0 0.1em #3d3d3d inset;
	}
	.search-btn {
		background: #f1f1f1;
	}
}
/* button-62 */
.button-62 {
  background: linear-gradient(to bottom right, rgb(235,84,64), rgba(225,84,64));
  border: 0;
  border-radius: 12px;
  color: #2b2e2e;
  cursor: pointer;
  display: inline-block;
  font-family: Open Sans, Montserrat;
  font-size: 16px;
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
