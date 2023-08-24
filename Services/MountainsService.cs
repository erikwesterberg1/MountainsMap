using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mountains.Models;

public class MountainsService {

    private readonly IMongoCollection<Mountain> _mountainsCollection;

    public MountainsService(IOptions<MountainsDatabaseSettings> settings)
    {
        //create client with connectionstring
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        // get database on name
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        //get collection
        _mountainsCollection = mongoDatabase.GetCollection<Mountain>(settings.Value.MountainsCollectionName);
    }

    private async Task<List<Mountain>> GetAsync() => 
        await _mountainsCollection.Find(_ => true).ToListAsync();
}