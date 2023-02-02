<template>
<body>
  <div class="navbar">
    <div class="container flex">
      <img src="./assets/logo_dtt.png">
      <nav>
        <ul>
          <a><router-link to="/">Home</router-link>| <router-link to="/about">About</router-link></a>
        </ul>
      </nav>
    </div>
  </div>

 <router-view/>
</body>

</template>



<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,500;0,600;1,500&family=Open+Sans:wght@400;600&family=Poppins:wght@200;400;600&display=swap');

body {
  font-family:Open Sans, Montserrat;
  line-height: 1.6;
  background-color: #F6F6F6 ;
  min-height:100vh;
  overflow: auto;

}

.container {
  max-width: auto;
  margin: auto;
  overflow: auto;
  padding: 0 40px;

}

.flex {
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 100%;
}

.navbar {
  background-color: rgb(235, 84, 64);
  color: rgb(3, 3, 3);
  height: 200px;
}
    
.navbar a {
  color: rgb(0, 0, 0);
  padding: 10px;
  margin: 0 5px;
}
  
nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color:white
}
</style>
