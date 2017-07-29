using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileFixtureTeam
    public class FileFixtureTeam 
    {
        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("team")]
        public FileFixtureInfo Team { get; set; }
    }
    #endregion
}
