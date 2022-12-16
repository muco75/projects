<template>

<div class="topnav">
  <a class="active" href="/">Home</a>
  <a href="/posof">All My Tasks</a>
</div>

<div class="background">
  <div>
    <router-view/> 
  </div>
</div>

 
 
<!-- <div>
  <nav class="navbar navbar-expand-lg navbar-light bg-light" >
    <a class="navbar-brand" href="#">ToDoApp</a>
    <button class="navbar-toggler">
    </button>
    <div>
      <ul class="navbar-nav">
        <li class="nav-item active">
          <a class="nav-link"  div id="nav"> <router-link to="/">Home</router-link></a>
        </li>
        <li class="nav-item">
          <a class="nav-link"  div id="nav"> <router-link to="/posof">All My Tasks</router-link></a>
        </li>
      </ul>
    </div>
  </nav>
  <router-view/>
</div> -->
</template>

<style scoped>
.background {
    background: url(@/assets/network.jpg) ;
    background-size: contain;
    background-repeat: no-repeat;
    width: 100%;
    height: 0;
    padding-top: 50%;
}

/* Add a black background color to the top navigation */
.topnav {
  background-color: #333;
  overflow: hidden;
}

/* Style the links inside the navigation bar */
.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

/* Change the color of links on hover */
.topnav a:hover {
  background-color: #ddd;
  color: black;
}

/* Add a color to the active/current link */
.topnav a.active {
  background-color: #085594;
  color: white;
}
</style>