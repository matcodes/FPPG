using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileNews
    public class FileNews
    {
        [JsonProperty("latest")]
        public DateTime Latest { get; set; }
    }
    #endregion
}
