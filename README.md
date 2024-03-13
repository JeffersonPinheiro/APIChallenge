# ToDo List

Uma API simples para gerenciar tarefas.

## Descrição

Esta API permite realizar operações CRUD (Criar, Ler, Atualizar, Deletar) em tarefas. Cada tarefa possui um título, uma descrição e um status.

## Recursos

- Listar todas as tarefas
- Obter uma tarefa específica pelo ID
- Criar uma nova tarefa
- Atualizar uma tarefa existente
- Deletar uma tarefa existente

## Rotas

### Listar todas as tarefas

GET /api/Tasks

### Obter uma tarefa pelo ID

GET /api/Tasks/id

### Criar uma nova tarefa

POST /api/Tasks

#### Corpo da requisição

```json
{
  "title": "Estudar",
  "description": "Estudar o framework Vue.js",
  "creation": "2024-03-13T16:18:48.067Z",
  "status": "Em andamento"
}
```json
### Atualizar uma tarefa existente

PUT /api/Tasks/id

#### Corpo da requisição

```json
{
  "title": "Estudar",
  "description": "Estudar o framework Vue.js",
  "creation": "2024-03-13T16:18:48.067Z",
  "status": "concluída"
}
```json

### Deletar uma tarefa existente

DELETE /api/Tasks/id

