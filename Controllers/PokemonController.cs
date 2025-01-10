using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<List<Pokemon>> Get()
        {
            return await _pokemonService.GetPokemonsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPokemon(string id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null) return NotFound("Pokemon not found");
            return Ok(pokemon);
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult> GetPokemonByName(string name)
        {
            var pokemon = await _pokemonService.GetPokemonByNameAsync(name);
            if (pokemon == null) return NotFound("Pokemon not found");
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon newPokemon)
        {
            var pokemon = await _pokemonService.AddPokemonAsync(newPokemon);
            return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            var pokemon = await _pokemonService.UpdatePokemonAsync(id, updatedPokemon);
            return Ok(pokemon);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(string id)
        {
            var deleted = await _pokemonService.DeletePokemonAsync(id);
            if (!deleted) return NotFound("Pokemon not found");
            return NoContent();
        }
    }
}
