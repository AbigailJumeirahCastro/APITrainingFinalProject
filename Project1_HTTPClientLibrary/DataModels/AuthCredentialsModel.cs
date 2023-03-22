using Newtonsoft.Json;

namespace Project1_HTTPClientLibrary.DataModels
{
    public class AuthCredentialsModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
