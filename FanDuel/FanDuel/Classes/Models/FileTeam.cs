using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileTeam
    public class FileTeam
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    #endregion
}
