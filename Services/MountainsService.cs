using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mountains.Models;

public class MountainsService {

    private readonly IMongoCollection<Mountain> _mountainsCollection;

    public MountainsService(IOptions<MountainsDatabaseSettings> settings)
    {
        //starta om dator och se om det fungerar
        string? conn = Environment.GetEnvironmentVariable("MOUNTAINSDB_CONNECTIONSTRING");
        //create client with connectionstring
        var mongoClient = new MongoClient(conn);
        // get database on name
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        //get collection
        _mountainsCollection = mongoDatabase.GetCollection<Mountain>(settings.Value.MountainsCollectionName);
    }

    public async Task<List<Mountain>> GetAsync() => await _mountainsCollection.Find(_ => true).ToListAsync();

    public async Task<Mountain?> GetAsync(string id) => await _mountainsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Mountain>> GetAsync(double metres) => await _mountainsCollection.Find(x => x.Metres > metres).ToListAsync();

    public async Task<List<Mountain>> GetByCountryAsync(string country) => await _mountainsCollection.Find(x => x.Location.Contains(country) == true).ToListAsync();

    public async Task CreateAsync(Mountain newMountain) => await _mountainsCollection.InsertOneAsync(newMountain);

    public async Task UpdateAsync(string id, Mountain updatedMountain) => await _mountainsCollection.ReplaceOneAsync(x => x.Id == id, updatedMountain);

    public async Task DeleteAsync(string id) => await _mountainsCollection.DeleteOneAsync(x => x.Id == id);

}