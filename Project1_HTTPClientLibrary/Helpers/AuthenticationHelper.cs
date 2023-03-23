using Newtonsoft.Json;
using Project1_HTTPClientLibrary.Resources;
using Project1_HTTPClientLibrary.Tests.TestData;
using System.Net.Http.Headers;
using System.Text;

namespace Project1_HTTPClientLibrary.Helpers
{
    internal class AuthenticationHelper
    {
        /// <summary> Make POST request to create token </summary>
        public static async Task<HttpResponseMessage> CreateToken(HttpClient httpClient)
        {
            // Create data
            var credentials = GenerateCredentials.credentials();

            // Create request
            var request = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make API call and return response
            return await httpClient.PostAsync(Endpoints.CreateTokenEndpoint(), content);

        }
    }
}
