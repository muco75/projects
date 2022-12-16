<template>
<div class="background" id="app">

  <div v-for="(todo, n) in todos" :key="todo.n">

    <i class="fas fa-minus ml-2"></i>
    
    <li class="mt-2 todo">
      {{ todo.name }}
    </li>
    
    <li class="button-container">
      <input class="ml-5 border border-primary rounded" v-if="!todo.isHidden" v-model="todo.name">
      
      <button @click="toggleTodo(n, todo)">
        <i v-if="todo.isHidden" class="THIS-CLICK">click-this</i>
        <i v-else class="far fa-save">save</i>
      </button>     
    </li>
  </div>

</div>

</template>
<script >

export default {
  data() {
    return {
      todos: [{
          name: 'wash hands',
          isHidden: true
        },
        {
          name: 'Stay home',
          isHidden: true
        }
      ],
    };
  },

  methods: {
    toggleTodo(n, todo) {
      let hidden = todo.isHidden;
      
      if (hidden) {
        this.modifyTodo(n, todo);
        todo.isHidden = false;
      } else {
        todo.isHidden = true;
      }
      
    },
    modifyTodo(n, todo) {
      console.log(n,todo)
    }
                 

    
  },
}


</script>

<style>
.background {
    background: url(@/assets/network.jpg) ;
    background-size: contain;
    background-repeat: no-repeat;
    width: 100%;
    height: 0;
    padding-top: 66.64%;
}
</style>