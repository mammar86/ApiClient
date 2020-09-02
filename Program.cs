using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

namespace ApiClient
{

    class Item
    {
        [JsonPropertyName("mission_name")]
        public string MissionName { get; set; }

        [JsonPropertyName("mission_id")]
        public string MissionId { get; set; }

        // public string manufacturers { get; set; } 
        // public string payload_ids { get; set; }

        [JsonPropertyName("wikipedia")]
        public string Wikipedia { get; set; }
    }


    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();

            var url = "https://api.spacexdata.com/v3/missions";

            var responseAsStream = await client.GetStreamAsync(url);

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            var table = new ConsoleTable("Mission Name", "Mission Id", "Wikipedia Link");


            foreach (var item in items)
            {

                // Console.WriteLine($"{item.MissionName} is a mission by spaceX its mission ID is {item.MissionId}. for more information about this mission payload please visit this link {item.Wikipedia}");
                table.AddRow(item.MissionName, item.MissionId, item.Wikipedia);
            }

            table.Write();




        }
    }
}
