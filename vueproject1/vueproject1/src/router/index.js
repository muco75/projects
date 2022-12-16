import { createRouter, createWebHistory } from 'vue-router'
import TodoApp from '../components/TodoApp.vue'
import MyTasks from '../components/MyTasks.vue'
import TestOfInput from '../components/TestOfInput.vue'




let routes = [
    {
        path: '/',
        name:'home',
        component: TodoApp,
        
    },
    
    {
        path: '/posof',
        name:'Tasks',
        component: MyTasks
    },
    {
        path: '/test',
        name:'Tests',
        component: TestOfInput
    }

]

const router = createRouter({
    history: createWebHistory(),
    routes
  })
  

export default router
