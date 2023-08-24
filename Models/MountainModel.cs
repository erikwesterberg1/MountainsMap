using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mountains.Models;

public class Mountain {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int? Id { get; set; }

    [BsonElement("Mountain")]
    public string Name { get; set; }
    public int Metres { get; set; }
    public int Feet { get; set; }
    public string Range { get; set; }
    public string Location { get; set; }

}