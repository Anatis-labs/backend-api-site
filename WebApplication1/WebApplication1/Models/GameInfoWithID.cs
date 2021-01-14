using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GameInfoWithID
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MinimumSystemRequirements    {
        public string os { get; set; } 
        public string processor { get; set; } 
        public string memory { get; set; } 
        public string graphics { get; set; } 
        public string storage { get; set; } 
    }

    public class Screenshot    {
        public int id { get; set; } 
        public string image { get; set; } 
    }

    public class RootWithId    {
        public int id { get; set; } 
        public string title { get; set; } 
        public string thumbnail { get; set; } 
        public string status { get; set; } 
        public string short_description { get; set; } 
        public string description { get; set; } 
        public string game_url { get; set; } 
        public string genre { get; set; } 
        public string platform { get; set; } 
        public string publisher { get; set; } 
        public string developer { get; set; } 
        public string release_date { get; set; } 
        public string freetogame_profile_url { get; set; } 
        public MinimumSystemRequirements minimum_system_requirements { get; set; } 
        public List<Screenshot> screenshots { get; set; } 
    }
    }
}
