<template>

<div  class="container" style="max-width: 600px" >
    <h2 class="text-center mt-5" style="color:steelblue">My tasks</h2>
    
    <!--Input-->
    <div class="d-flex">
        <input ref="inputRef" v-model="item.task" type="text" placeholder="Enter task" class="form-control">
        <button @click="addTask" class="btn btn-warning rounded-0">SUBMIT</button>
        <select v-model="item.status" >
            <option place value="to-do">to-do</option>
            <option value="In-progress">In-progress</option>
            <option value="finished">finished</option>
        </select>
    </div>
    
    <!--Task table-->
    <div v-if="loading === false">
        <table class="table table-bordered mt-5">
            <thead>
                <tr>
                    <th scope="col" style="color:darksalmon">Task</th>
                    <th scope="col" style="color:darksalmon">status</th>
                    <th scope="col" class="text-center" style="color:blue">Change</th>
                    <th scope="col" class="text-center" style="color:red" >Delete</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(task, index) in tasks" :key="task" style="color:black">
                    <td>
                        {{task.task}}
                    </td>
                    <td style="width: 120px"  @click="changeStatus(task)" class="pointer"
                        :class="{'text-danger': task.status === 'to-do',
                        'text-warning': task.status === 'in-progress',
                        'text-success': task.status === 'finished',
                        }">
                        <span>
                            {{firstCharUpper(task.status)}}
                        </span>
                    </td>
                    <td>
                        <input class="ml-5 border border-primary rounded" v-if="!task.isEditing" v-model="task.task">
                        
                        <button v-if="task.isEditing" @click="editTask(task)" >
                            <i class="fa fa-pen"></i>
                        </button>
                        <button v-else @click="saveTask(task)">
                            <i class="far fa-save"></i>
                        </button>
                    </td>
                    <td >
                        <div class="text-center" >
                            <button @click="deleteTask(task,index)">
                                <i class="fa fa-trash"></i>
                            </button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    
    <div class="fa-2x" v-else>
        <i class="fa-solid fa-spinner fa-spin-pulse"></i>
        <span>loading tasks</span>
    </div>

</div>





</template>

<script>



export default {

    data () {
       
        return {
             
            tasks: [],//get items
            editedTask: null,
            availableStatuses:['to-do','in-progress','finished' ],
            loading : true,
            item: {   // send items
                task:'',
                status: '',
                
            },
            
            
        }
    },
    
    mounted () {
        this.$refs.inputRef.focus()
        
        fetch('todo/get')
        .then(response => this.tasks = response.json())
        .then((data) => this.tasks = data.map(x => {
                x.isEditing = true;
                return x;
            }))
        .finally(() => this.loading = false)
        

    },


     methods: {
        //add

        addTask(){

            fetch('/todo/add', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(this.item),
                
            })
            .catch((error) => {console.error('Error:', error);})
            
            this.tasks.push({
                task:this.item.task,
                status:this.item.status,
                isEditing:true,
            })
           
            
        },   

        

        //delete

         deleteTask(task,index){

                fetch('/todo/delete/'+ task.id, { 
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                }})
                .catch((error) => {console.error('Error:', error);}),

                
                this.tasks.splice(index);
                
        },
        
        // save task

        saveTask(task){
            
            fetch('/todo/update/'+ task.id, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                 body: JSON.stringify(task),
                })
                console.log(task)

                task.isEditing = true
            },
        
        // change status

        changeStatus(task){
            let newTask = this.availableStatuses.indexOf(task.status);
            if(++newTask > 2) newTask = 0;
            task.status = this.availableStatuses[newTask]
            
            console.log(this.tasks)
            
            fetch('/todo/update/'+ task.id, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(task),
            })
        },
                
                
        editTask(task){

            task.isEditing = false
        },
        
       //first capital 
        firstCharUpper(str){
            return str.charAt(0).toUpperCase() + str.slice(1);
        },
    }
}

</script>


<style scoped>

.pointer{
    cursor: pointer;
}

.finished{
    text-decoration: line-through;
}

.table{
    width: 100%;
    border-collapse: collapse;
}

.table td, table th{
    padding: 12px 15 px;
    border: 1px solid #fff;
    
}

.container{
    position: absolute;
    top: 0;
    bottom: 0;
    right: 0;
    left: 0;
    color: black;
    text-align: center;
    margin-top: 5%;
}


</style>