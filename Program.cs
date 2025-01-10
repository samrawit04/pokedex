using pokedex.Data;
using pokedex.Services;
using DotNetEnv;
// Load environment variables from the .env file
Env.Load();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PokemonDbContext>(builder.Configuration);
builder.Services.AddSingleton<PokemonDbContext>();
builder.Services.AddScoped<IPokemonService, PokemonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();


