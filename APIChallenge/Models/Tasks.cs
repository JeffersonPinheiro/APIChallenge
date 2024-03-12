using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace APIChallenge.Models;

[BsonIgnoreExtraElements]
public class Tasks {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? name {get; set;}

    public string?  description { get; set; }

    public string?  priority { get; set; }
}