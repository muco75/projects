<template>

    <div class="button-62">
        <input  ref="file" type="file"> 
    </div>

    <router-link to="/">
<button class="button-62"  @click="saveImageHouse(house)">
        Save image
    </button>

    </router-link>
    


</template>

<script>

export default {
    data () {
        return {
            house: {
                image:'',
            }
        }
    },
    methods: {

        saveImageHouse(){
            let myHeaders = new Headers();
            myHeaders.append("X-Api-Key", "73e_ERkfjLsFYG5vc81KP4TonQJSH6wr");

            let formdata = new FormData();
            formdata.append('image', this.$refs.file.files[0], "rainy-day.jpg");

            let requestOptions = {
                method: 'POST',
                headers:{
                    'X-Api-Key':'73e_ERkfjLsFYG5vc81KP4TonQJSH6wr',
                    'Content-Type' : 'multipart/form-data'
                },
                body: formdata,
                redirect: 'follow'
            };

            fetch(`https://api.intern.d-tt.nl/api/houses/${this.$route.params.id}/upload`, requestOptions)
            .then(result => console.log(result))
            .catch(error => console.log('error', error));
        },
    }
}



</script>

<style scoped>
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
