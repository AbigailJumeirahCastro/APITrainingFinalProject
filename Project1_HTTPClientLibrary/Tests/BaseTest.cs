using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Project1_HTTPClientLibrary.Helpers;
using Project1_HTTPClientLibrary.DataModels;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]

namespace Project1_HTTPClientLibrary.Tests
{

    public class BaseTest
    {
        public static HttpClient httpClient { get; set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Authenticate
            var createTokenResponse = await AuthenticationHelper.CreateToken(httpClient);
            var createTokenResponseData = JsonConvert.DeserializeObject<TokenModel>(createTokenResponse.Content.ReadAsStringAsync().Result);
            if (httpClient.DefaultRequestHeaders.Contains("Cookie"))
                httpClient.DefaultRequestHeaders.Remove("Cookie");
            httpClient.DefaultRequestHeaders.Add("Cookie", $"token={createTokenResponseData.Token}");
        }

    }

}
