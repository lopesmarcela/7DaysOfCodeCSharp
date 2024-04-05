using Newtonsoft.Json;
using RestSharp;
using System;

class Program{
    static void Main(string[] args){
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest();
        var response = client.Execute(request);

        var pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        for (int i = 0; i < pokemonSpecies.Results.Count; i++)
        {
            Console.WriteLine($"{i+1} - {pokemonSpecies.Results[i].Name}");
        }
    }
}
