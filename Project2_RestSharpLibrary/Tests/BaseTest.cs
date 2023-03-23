using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Project2_RestSharpLibrary.Helpers;
using Project2_RestSharpLibrary.DataModels;
using RestSharp;
using Newtonsoft.Json.Linq;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]

namespace Project2_RestSharpLibrary.Tests
{
    public class BaseTest
    {
        public RestClient restClient { get; set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            // Authenticate
            var createTokenResponse = await AuthenticationHelper.CreateToken(restClient);
            var createTokenResponseData = JsonConvert.DeserializeObject<TokenModel>(createTokenResponse.Content);
            restClient.AddDefaultHeader("Cookie", $"token={createTokenResponseData.Token}");
        }

    }

}
