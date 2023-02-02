<template>

<div class="container">

  <div class="header">
    <h3 class="h1"><router-link to="/"><i class="fa-solid fa-circle-arrow-left"></i></router-link>Back to overview</h3>
    <h1 class="h1"> Create new listing</h1>
  </div>

  <div>
    <p class="error" v-if="errors.length">
      <b>Please correct the following error(s):</b>
      <ul>
        <li v-for="error in errors" :key="error">{{ error }}</li>
      </ul>
      </p>
    <form>
      <div class="group">
        <input type="text" v-if="!required" v-model="house.location.street">
        <span class="highlight"></span>
        <span class="bar"></span>
        <label>Street</label>
      </div>

      <div class="group">      
          <input type="text" required v-model="house.location.zip">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Zip</label>
      </div>

      <div class="group">      
          <input type="text" required v-model="house.location.city">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>City</label>
      </div>

      <div class="group">
          <input type="number" required v-model="house.price">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Price</label>
      </div>

      <div> 
          <div class="group">      
              <input type="number" required v-model="house.size">
              <span class="highlight"></span>
              <span class="bar"></span>
              <label>size m²</label>
          </div>
          <div class="group">      
              <input type="text" required v-model="house.hasGarage">
              <span class="highlight"></span>
              <span class="bar"></span>
              <label>Garage</label>
          </div>
      </div>
      
      <div class="group">      
          <input type="number" required v-model="house.rooms.bedrooms">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Bedrooms</label>
          <span></span>
      </div>

      <div class="group">      
          <input type="number" required v-model="house.rooms.bathrooms">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Bathrooms</label>
      </div>

      <div class="group">      
          <input type="number" required v-model="house.constructionYear">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Construction year</label>

      </div>

      <div class="group">      
          <input class="groupDescription" type="textarea" required v-model="house.description">
          <span class="highlight"></span>
          <span class="bar"></span>
          <label>Description</label>
      </div>
    </form>
  </div>

  <div class="group">
    <button class="button-62" @click="saveNewHouse(house)" role="button">Save and Upload image</button>
    <div v-if="required === true"></div>
  </div>
</div>


</template>

<script>
export default {
  data () {
    return {
      errors: [],
      house: {
        price:'',
        location:{
          street:'',
          city:'',
          zip:''
        },
        rooms:{
          bedrooms:'',
          bathrooms:''
        },
        description:'',
        size:'',
      }
    }
  },

  methods: {
    saveNewHouse(house){
      let myHeaders = new Headers();
      myHeaders.append("X-Api-Key", "73e_ERkfjLsFYG5vc81KP4TonQJSH6wr");
      let formdata = new FormData();
      formdata.append("price", house.price);
      formdata.append("bedrooms", house.rooms.bedrooms);
      formdata.append("bathrooms", house.rooms.bedrooms );
      formdata.append("size", house.size);
      formdata.append("streetName", house.location.street);
      formdata.append("houseNumber", "21");
      formdata.append("numberAddition", "1");
      formdata.append("zip", house.location.zip);
      formdata.append("city", house.location.city);
      formdata.append("constructionYear", house.constructionYear);
      formdata.append("hasGarage", house.hasGarage )
      formdata.append("description", house.description);
      
      let addHouse = {
        method: 'POST',
        headers: myHeaders,
        body: formdata,
        redirect: 'follow'
      };
      fetch("https://api.intern.d-tt.nl/api/houses", addHouse)
      .then(response => response.json())
      .then(response => {
        let id = response.id;
        this.$router.push({ name:'uploadImage', params: { id: id } })
      })
      .catch(error => console.log('error', error))

      this.errors = [];

      if (!this.house.location.street) {
        this.errors.push('Street required.');
      }
      if (!this.house.location.zip) {
        this.errors.push('Zip required.');
      }
      if (!this.house.price) {
        this.errors.push('Price required.');
      }
      if (!this.house.size) {
        this.errors.push('Size required.');
      }
      if (!this.house.price) {
        this.errors.push('Price required.');
      }
      if (!this.house.hasGarage) {
        this.errors.push('Garage required.');
      }
      if (!this.house.rooms.bedrooms) {
        this.errors.push('Bedrooms required.');
      }
      if (!this.house.rooms.bathrooms) {
        this.errors.push('Bathrooms required.');
      }
      if (!this.house.constructionYear) {
        this.errors.push('Construction Year required.');
      }
      if (!this.house.description) {
        this.errors.push('Description required.');
      }
    },
  }
}

</script>

<style scoped>
.error {
  position:relative; 
  margin-bottom:45px; 
  margin-left: 200px;
  margin-top: 50px;
  size: 100px;
  color: red;
}


.groupDescription {
    height: 100px;
    width:400px;

}
.header {
    display: flex;
    flex-direction: column;
}
.container {
    background: url(@/assets/img_background.png) ;
    min-height: 150vh;
    background-size: 100%;    
}
    
* {
    box-sizing:border-box;
}

.footer   { text-align:center; }
.footer a  { color:#53B2C8; }

.h1 {
    margin-left: 200px;
}

/*  input fields */
.group { 
  position:relative; 
  margin-bottom:45px; 
  margin-left: 200px;
  margin-top: 50px;
  size: 100px;
}
input         {
  font-size:18px;
  padding:10px 10px 10px 5px;
  display:block;
  width:400px;
  border:none;
  border-bottom:1px solid #757575;
}
input:focus     { outline:none; }

/* LABEL ======================================= */
label          {
  color:#999; 
  font-size:18px;
  font-weight:normal;
  position:absolute;
  pointer-events:none;
  left:5px;
  top:10px;
  transition:0.2s ease all; 
  -moz-transition:0.2s ease all; 
  -webkit-transition:0.2s ease all;
}

/* active state */
input:focus ~ label, input:valid ~ label    {
  top:-20px;
  font-size:14px;
  color:#5264AE;
}

/* BOTTOM BARS ================================= */
.bar  { position:relative; display:block; width:300px; }
.bar:before, .bar:after   {
  content:'';
  height:2px; 
  width:0;
  bottom:1px; 
  position:absolute;
  background:#5264AE; 
  transition:0.2s ease all; 
  -moz-transition:0.2s ease all; 
  -webkit-transition:0.2s ease all;
}
.bar:before {
  left:50%;
}
.bar:after {
  right:50%; 
}

/* active state */
input:focus ~ .bar:before, input:focus ~ .bar:after {
  width:50%;
}

/* HIGHLIGHTER ================================== */
.highlight {
  position:absolute;
  height:60%; 
  width:100px; 
  top:25%; 
  left:0;
  pointer-events:none;
  opacity:0.5;
}

/* active state */
input:focus ~ .highlight {
  -webkit-animation:inputHighlighter 0.3s ease;
  -moz-animation:inputHighlighter 0.3s ease;
  animation:inputHighlighter 0.3s ease;
}

/* ANIMATIONS ================ */
@-webkit-keyframes inputHighlighter {
  from { background:#5264AE; }
  to  { width:0; background:transparent; }
}
@-moz-keyframes inputHighlighter {
  from { background:#5264AE; }
  to  { width:0; background:transparent; }
}
@keyframes inputHighlighter {
  from { background:#5264AE; }
  to  { width:0; background:transparent; }
}

/* button 62 */

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