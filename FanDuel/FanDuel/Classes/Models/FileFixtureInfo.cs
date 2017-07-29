using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileFixtureInfo
    public class FileFixtureInfo
    {
        [JsonProperty("_members")]
        public string[] Members { get; set; }

        [JsonProperty("_ref")]
        public string Ref { get; set; }
    }
    #endregion
}
