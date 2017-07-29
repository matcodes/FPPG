using FanDuel.Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FanDuel.Classes.API
{
    #region FanDuelAPI
    public static class FanDuelAPI
    {
        public static readonly string CONTENT_FILE_URI = @"https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";

        public static FilePlayers LoadContent()
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData(CONTENT_FILE_URI);
            var text = Encoding.UTF8.GetString(data);

            var filePlayers = JsonConvert.DeserializeObject<FilePlayers>(text);
            return filePlayers;
        }
    }
    #endregion
}
