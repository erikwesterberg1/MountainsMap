using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Climber {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? name { get; set; }
    public List<string> mountains { get; set; } = new List<string>();
    public int age { get; set; }
    public string? nationality { get; set; }
    public bool alive { get; set; } 

}