using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace APIChallenge.Models;

[BsonIgnoreExtraElements]
public class Tasks {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? title {get; set;}

    public string?  description { get; set; }

    public DateTime?  creation { get; set; }

    public string? status { get; set; }
}