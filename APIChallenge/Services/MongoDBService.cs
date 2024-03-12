using APIChallenge.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace APIChallenge.Services;

public class MongoDBService{

    private readonly IMongoCollection<Tasks> _tasksCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _tasksCollection = database.GetCollection<Tasks>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Tasks tasks){
        await _tasksCollection.InsertOneAsync(tasks);
        return;
    }

    public async Task<List<Tasks>> GetAsync(){
        return await _tasksCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToUsersAsync(string id, string taskId){
        FilterDefinition<Tasks> filter = Builders<Tasks>.Filter.Eq("Id", id);
        UpdateDefinition<Tasks> update = Builders<Tasks>.Update.AddToSet<string>("taskId", taskId);
        await _tasksCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id) {
        FilterDefinition<Tasks> filter = Builders<Tasks>.Filter.Eq("Id", id);
        await _tasksCollection.DeleteOneAsync(filter);
        return;
    }
}