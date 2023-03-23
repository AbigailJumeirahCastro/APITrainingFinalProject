using Newtonsoft.Json;

namespace Project2_RestSharpLibrary.DataModels
{
    public class AuthCredentialsModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
