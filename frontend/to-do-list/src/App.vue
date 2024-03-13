<template>
  <div class ="container mx-auto max-w-xl px-5 py-10">
    <h1>ToDo List</h1>
    <div class="adicionar">
      <form @submit.prevent="addTask" class="form">
        <input type="text" ref="itemNameInput" placeholder="Nome do novo item">
        <!-- <input type="text" v-model="newItemName" placeholder="Descrição"> -->
        <button type="submit" class="adicionar-btn">Adicionar</button>
      </form> 
    </div>    
    <div>
          <div
              v-for="task in tasks"
              :key="task.id"
              class="item"
            >
            {{ task.title }}
            <button @click="deleteTask(task.id)" class="delete-btn">Deletar</button>
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

<style scoped>
/* Estilo global */
body, h1, h2, h3, h4, h5, h6, p, ul, li, button {
  font-family: Verdana, sans-serif;
}

.adicionar{
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 10px;
}

.form{
  display: flex;
    justify-content: space-between;
    width: -webkit-fill-available;
}

.item-list {
  list-style: none;
  padding: 0;
}

.item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 10px;
}

.item span {
  flex-grow: 1;
}

.adicionar-btn {
  margin-left: 10px;
  background-color: #87cefa;
  color: white;
  border: none;
  padding: 5px 10px;
  border-radius: 5px;
  cursor: pointer;
}

.delete-btn {
  margin-left: 10px;
  background-color: #e74c3c;
  color: white;
  border: none;
  padding: 5px 10px;
  border-radius: 5px;
  cursor: pointer;
}
</style>
