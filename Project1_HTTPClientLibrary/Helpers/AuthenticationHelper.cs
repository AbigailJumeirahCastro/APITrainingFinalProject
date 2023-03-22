using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Project1_HTTPClientLibrary.DataModels;
using Project1_HTTPClientLibrary.Resources;
using Project1_HTTPClientLibrary.Tests.TestData;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Project1_HTTPClientLibrary.Helpers
{
    internal class AuthenticationHelper
    {
        /// <summary>
        /// Make POST request to create token
        /// </summary>

        public static async Task<TokenModel> GetTokenData(HttpClient httpClient)
        {
            // Create JSON Object
            var credentials = GenerateCredentials.credentials();

            // Create the request content as JSON
            var request = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");

            // Add header to the request to accept JSON content
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make POST Request
            var response = await httpClient.PostAsync(Endpoints.GetURL(Endpoints.AuthEndpoint), content);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code is not equal to 200");

            // Deserialize response data
            var responseData = JsonConvert.DeserializeObject<TokenModel>(response.Content.ReadAsStringAsync().Result);

            // Return the deserialized response data
            return responseData;
        }
    }
}
