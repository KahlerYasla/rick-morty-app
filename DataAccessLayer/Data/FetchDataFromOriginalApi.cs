using System.Net.Http.Json;
using System.Text.Json.Serialization;
using DataAccessLayer.Data;
using rick_morty_app.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace rick_morty_app.DataAccessLayer.Data
{

    public static class FetchDataFromOriginalApi
    {
        private static DataContext? _dataContext;

        public static async Task FetchAndWriteDataAsync()
        {
            _dataContext = new DataContext();

            List<Character> characters = await FetchAndWriteEpisodesAsync();
            List<Episode> episodes = await FetchAndWriteCharactersAsync();

            Console.WriteLine("\nWriting characters and episodes to the database...");
            Console.WriteLine($"Characters: {characters.Count} - Episodes: {episodes.Count}");

            Console.WriteLine("\nExample character:");
            Console.WriteLine($"Name: {characters[0].Name}");
            Console.WriteLine($"Status: {characters[0].Status}");
            Console.WriteLine($"Species: {characters[0].Species}");
            Console.WriteLine($"Type: {characters[0].Type}");
            foreach (var episode in characters[0].EpisodeIds)
            {
                Console.WriteLine($"Episode: {episode}");
            }

            Console.WriteLine("\nExample episode:");
            Console.WriteLine($"Name: {episodes[0].EpisodeName}");
            Console.WriteLine($"Air date: {episodes[0].AirDate}");
            Console.WriteLine($"Episode code: {episodes[0].EpisodeCode}");
            foreach (var character in episodes[0].CharacterIds)
            {
                Console.WriteLine($"Character: {character}");
            }

            Console.WriteLine("\n");

            _dataContext.Characters.AddRange(characters);
            _dataContext.Episodes.AddRange(episodes);

            _dataContext.SaveChanges();

            SetRelationships();

            _dataContext.SaveChanges();
        }
        // ---------------------------------------------------------------------------------------------------
        private static async Task<List<Character>> FetchAndWriteEpisodesAsync()
        {
            Console.WriteLine("\nFetching characters from the API...");

            List<Character> characters = new();

            for (int i = 0; i < 42; i++)
            {
                string apiUrl = "https://rickandmortyapi.com/api/character?page=" + (1 + i);

                using HttpClient client = new();
                // Make the HTTP request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the whole content as a string
                    string rawContentString = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a list of characters
                    var result = JsonSerializer.Deserialize<CharacterResults>(rawContentString);

                    Console.WriteLine($"\nFetched {result?.Results?.Count} characters from the API from page {i + 1}");

                    // Get the first character from the list and print its name
                    if (result?.Results?.Count > 0)
                    {
                        Console.WriteLine($"First character of the page: {result?.Results?[0].Name}\n");
                    }

                    characters.AddRange(result?.Results ?? new List<Character>());
                }
                else
                {
                    // Handle the error if the request was not successful
                    Console.WriteLine($"Error from characters: {response.StatusCode} - {response.ReasonPhrase}");
                    return new List<Character>();
                }
            }

            return characters;
        }
        // ---------------------------------------------------------------------------------------------------
        private static async Task<List<Episode>> FetchAndWriteCharactersAsync()
        {
            Console.WriteLine("\nFetching episodes from the API...");

            List<Episode> episodes = new();

            for (int j = 0; j < 3; j++)
            {
                string apiUrl = "https://rickandmortyapi.com/api/episode?page=" + (1 + j);

                using HttpClient client = new();
                // Make the HTTP request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the whole content as a string
                    string rawContentString = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(rawContentString);

                    // Deserialize the JSON response into a list of episodes
                    var result = JsonSerializer.Deserialize<EpisodeResults>(rawContentString);

                    Console.WriteLine($"\nFetched {result?.Results?.Count} episodes from the API from page {1 + j}");

                    // Get the first episode from the list and print its name
                    if (result?.Results?.Count > 0)
                    {
                        Console.WriteLine($"First episode of the page: {result?.Results?[0].EpisodeName}\n");
                    }

                    episodes.AddRange(result?.Results ?? new List<Episode>());
                }
                else
                {
                    // Handle the error if the request was not successful
                    Console.WriteLine($"Error from episodes: {response.StatusCode} - {response.ReasonPhrase}");
                    return new List<Episode>();
                }
            }

            return episodes;
        }
        // ---------------------------------------------------------------------------------------------------
        private class CharacterResults
        {
            [JsonPropertyName("results")]
            public List<Character>? Results { get; set; }
        }

        private class EpisodeResults
        {
            [JsonPropertyName("results")]
            public List<Episode>? Results { get; set; }
        }
        // ---------------------------------------------------------------------------------------------------
        private static void SetRelationships()
        {
            foreach (var episode in _dataContext!.Episodes)
            {

                foreach (var character in _dataContext.Characters)
                {

                    if (episode.CharacterIds.Contains(character.Id.ToString()))
                    {
                        episode.Characters.Add(character);
                        character.Episodes.Add(episode);

                        Console.WriteLine($"Added relationship between {character.Name} and {episode.EpisodeName}");
                    }
                }
            }
        }
    }
}