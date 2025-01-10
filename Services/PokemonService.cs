using MongoDB.Driver;
using pokedex.Data;
using pokedex.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon> _pokemons;

        public PokemonService(PokemonDbContext context)
        {
            _pokemons = context.Pokemons;
        }

        public async Task<List<Pokemon>> GetPokemonsAsync()
        {
            return await _pokemons.Find(pokemon => true).ToListAsync();
        }

        public async Task<Pokemon> GetPokemonByIdAsync(string id)
        {
            return await _pokemons.Find(pokemon => pokemon.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pokemon> GetPokemonByNameAsync(string name)
        {
            return await _pokemons.Find(pokemon => pokemon.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Pokemon> AddPokemonAsync(Pokemon newPokemon)
        {
            await _pokemons.InsertOneAsync(newPokemon);
            return newPokemon;
        }

        public async Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon)
        {
            await _pokemons.ReplaceOneAsync(pokemon => pokemon.Id == id, updatedPokemon);
            return updatedPokemon;
        }

        public async Task<bool> DeletePokemonAsync(string id)
        {
            var result = await _pokemons.DeleteOneAsync(pokemon => pokemon.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
