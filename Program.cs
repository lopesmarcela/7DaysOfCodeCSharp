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

        Console.Write("Escolha qual pokemon deseja ver as habilidades: ");
        int option = int.Parse(Console.ReadLine());

        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{option}/");
        request = new RestRequest();
        response = client.Execute(request);

        var pokemonDetails = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        Console.WriteLine($"Nome: {pokemonDetails.Name}");
        Console.WriteLine($"Altura: {pokemonDetails.Height}");
        Console.WriteLine($"Peso: {pokemonDetails.Weight}");
        Console.WriteLine("Habilidades: ");
        for (int i = 0; i < pokemonDetails.Abilities.Count; i++)
        {
            Console.WriteLine($"{pokemonDetails.Abilities[i].Ability.Name}");
        }
        
    }
}
