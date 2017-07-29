using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileMetadataPlayers
    public class FileMetadataPlayers
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
    #endregion
}
