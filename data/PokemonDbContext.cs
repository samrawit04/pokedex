using MongoDB.Driver;
using pokedex.Models;

namespace pokedex.Data
{
    public class PokemonDbContext
    {
        private readonly IMongoDatabase _database;

        public PokemonDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            _database = client.GetDatabase("PokedexDb");
        }

        public IMongoCollection<Pokemon> Pokemons => _database.GetCollection<Pokemon>("Pokemons");
    }
}
