using mountains.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<MountainsDatabaseSettings>(builder.Configuration.GetSection("MountainsDatabase"));

/*It is recommended to store a MongoClient instance in a global place, 
either as a static variable or in an IoC container with a singleton lifetime. 
https://mongodb.github.io/mongo-csharp-driver/2.14/reference/driver/connecting/#re-use */

builder.Services.AddSingleton<MountainsService>();
builder.Services.AddSingleton<ClimbersService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
