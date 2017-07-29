using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileImage
    public class FileImage
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("url")]
        public string Uri { get; set; }
    }
    #endregion
}
