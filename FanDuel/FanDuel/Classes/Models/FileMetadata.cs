using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileMetadata
    public class FileMetadata
    {
        [JsonProperty("_primary_document")]
        public string PrimaryDocument { get; set; }

        [JsonProperty("players")]
        public FileMetadataPlayers Players { get; set; }
    }
    #endregion
}
