using System;
using Microsoft.AspNetCore.Mvc;
using APIChallenge.Services;
using APIChallenge.Models;

namespace APIChallenge.Controllers;
[Controller]
[Route("api/[controller]")]
public class TasksController: Controller {

    private readonly MongoDBService _mongoDBService;

    public TasksController(MongoDBService mongoDBService){
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Tasks>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tasks tasks) {
        await _mongoDBService.CreateAsync(tasks);
        return CreatedAtAction(nameof(Get), new {id = tasks.Id}, tasks);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToUsers(string id, [FromBody] string taskId) {
        await _mongoDBService.AddToUsersAsync(id, taskId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}