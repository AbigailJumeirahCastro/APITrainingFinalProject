using Newtonsoft.Json;

namespace Project1_HTTPClientLibrary.DataModels
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
