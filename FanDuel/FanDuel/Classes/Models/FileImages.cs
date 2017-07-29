using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.Classes.Models
{
    #region FileImage
    public class FileImages 
    {
        [JsonProperty("default")]
        public FileImage Default { get; set; }
    }
    #endregion
}
