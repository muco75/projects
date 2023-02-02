import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import HouseDetails from '@/components/HouseDetails.vue'
import HouseEdit from '@/components/HouseEdit.vue'
import AddHouse from '@/components/AddHouse.vue'
import HouseImage from '@/components/HouseImageUpload.vue'



const routes = [
  {
    path: '/', 
    name: 'home',
    component: HomeView
  },
  {
    path: '/details/:id',
    name: 'houses',
    component: HouseDetails
  },{
    path: '/add',
    name: 'addhouses',
    component: AddHouse
  },
  {
    path: '/details/edit/:id',
    name: 'houseEdit',
    component: HouseEdit
  },
  {
    path: '/add/upload/:id',
    name: 'uploadImage',
    component: HouseImage
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})



export default router
