using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mountains.Models;

public class DbConnService {
    public readonly IMongoDatabase database;

    public DbConnService(IOptions<MountainsDatabaseSettings> settings)
    {
        //Fetch string from environment variables
        string? conn = Environment.GetEnvironmentVariable("MOUNTAINSDB_CONNECTIONSTRING");
        //create client with connectionstring
        var mongoClient = new MongoClient(conn);
        // get database on name
        database = mongoClient.GetDatabase(settings.Value.DatabaseName);
    }

}