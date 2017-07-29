using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FilePlayers
    public class FilePlayers 
    {
        [JsonProperty("_meta")]
        public FileMetadata Meta { get; set; }

        [JsonProperty("fixtures")]
        public FileFixture[] Fixtures { get; set; }

        [JsonProperty("players")]
        public FilePlayer[] Players { get; set; }

        [JsonProperty("teams")]
        public FileTeam[] Teams { get; set; }
    }
    #endregion
}
