using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FilePlayer
    public class FilePlayer
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("fixture")]
        public FileFixtureInfo Fixture { get; set; }

        [JsonProperty("fppg")]
        public double? FPPG { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public FileImages Images { get; set; }

        [JsonProperty("injured")]
        public bool Injured { get; set; }

        [JsonProperty("injury_details")]
        public string InjuryDetails { get; set; }

        [JsonProperty("injury_status")]
        public string InjuryStatus { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("news")]
        public FileNews News { get; set; }

        [JsonProperty("played")]
        public int? Played { get; set; }

        [JsonProperty("player_card_url")]
        public string PlayerCardUrl { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("removed")]
        public bool Removed { get; set; }

        [JsonProperty("salary")]
        public int Salary { get; set; }

        [JsonProperty("starting_order")]
        public string StartingOrder { get; set; }

        [JsonProperty("team")]
        public FileFixtureInfo Team { get; set; } 
    }
    #endregion
}
