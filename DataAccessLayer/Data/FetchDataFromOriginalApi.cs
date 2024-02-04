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
            _dataContext.Characters.AddRange(characters);

            // List<Episode> episodes = await FetchAndWriteCharactersAsync();
            // _dataContext.Episodes.AddRange(episodes);

            _dataContext.SaveChanges();
        }

        private static async Task<List<Character>> FetchAndWriteEpisodesAsync()
        {
            string apiUrl = "https://rickandmortyapi.com/api/character";

            using HttpClient client = new();
            // Make the HTTP request
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string
                string rawContentString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of characters
                var result = JsonSerializer.Deserialize<CharacterJsonResponse>(rawContentString);

                // Return the list of characters
                return result?.Results ?? new List<Character>();
            }
            else
            {
                // Handle the error if the request was not successful
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return new List<Character>();
            }
        }

        private class CharacterJsonResponse
        {
            [JsonPropertyName("results")]
            public List<Character>? Results { get; set; }
        }

    }
}