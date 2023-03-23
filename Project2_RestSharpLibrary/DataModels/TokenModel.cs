using Newtonsoft.Json;

namespace Project2_RestSharpLibrary.DataModels
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
