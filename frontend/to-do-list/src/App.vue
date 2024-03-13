<template>
  <div class ="container mx-auto max-w-xl px-5 py-10">
    <h1>ToDo List</h1>
    <!-- Formulário para adicionar um novo item -->
    <form @submit.prevent="addTask">
      <input type="text" ref="itemNameInput" placeholder="Nome do novo item">
      <!-- <input type="text" v-model="newItemName" placeholder="Descrição"> -->
      <button type="submit">Adicionar</button>
    </form>  
    
    <div>
          <div
              v-for="task in tasks"
              :key="task.id"
            >
            {{ task.title }}
            <button @click="deleteTask(task.id)">Deletar</button>
          </div>    
    </div>
    <pre>{{ tasks }}</pre>
  </div>
  
</template>

<script>
import axios from "axios";
import {ref} from "vue";

const tasks = ref()

export default {
  
  data() {
    return {
     tasks: []
    };
  },
  mounted(){
    this.getTasks();
  },
  methods: {

      async getTasks(){
       const response = await axios.get('http://localhost:5171/api/Tasks')
        this.tasks = response.data;
        }, catch (error) {
          console.error('Erro ao carregar itens:', error);
      },
      addTask(){
      const newItemName = this.$refs.itemNameInput.value; 

      axios.post(`http://localhost:5171/api/Tasks/`, {title: newItemName})
      .then((response) => {
        console.log('Item adicionado com sucesso:', response.data);
        tasks.value = response.data    
      })
      .catch(err => { 
        console.log(err); 
      })
    },

    async deleteTask(id){
        await axios.delete(`http://localhost:5171/api/Tasks/${id}`)
        // eslint-disable-next-line
            const idx = this.tasks.findIndex(o => o.id === id)
            this.tasks.splice(idx, 1)
      }
    }
}

</script>

<style>

</style>
