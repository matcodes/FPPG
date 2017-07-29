using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileFixture
    public class FileFixture
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sport")]
        public string Sport { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("away_team")]
        public FileFixtureTeam AwayTeam { get; set; }

        [JsonProperty("home_team")]
        public FileFixtureTeam HomeTeam { get; set; }
    }
    #endregion
}
