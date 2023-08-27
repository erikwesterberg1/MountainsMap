using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mountains.Models;

public class ClimbersService: DbConnService {
    private readonly IMongoCollection<Climber> _climbersCollection;

    public ClimbersService(IOptions<MountainsDatabaseSettings> settings) : base(settings)
    {
       _climbersCollection = database.GetCollection<Climber>("Climbers");
    }

    public async Task<List<Climber>> GetAsync() => await _climbersCollection.Find(_ => true).ToListAsync();
}