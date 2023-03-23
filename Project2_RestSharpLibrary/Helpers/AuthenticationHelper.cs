using Project2_RestSharpLibrary.DataModels;
using Project2_RestSharpLibrary.Resources;
using Project2_RestSharpLibrary.Tests.TestData;
using RestSharp;

namespace Project2_RestSharpLibrary.Helpers
{
    internal class AuthenticationHelper
    {
        /// <summary> Make POST request to create token </summary>
        public static async Task<RestResponse> CreateToken(RestClient restClient)
        {
            // Create data
            var credentials = GenerateCredentials.credentials();

            // Create request
            var request = new RestRequest(Endpoints.CreateTokenEndpoint());
            request.AddJsonBody(credentials);
            request.AddHeader("Content-Type", "application/json");

            // Make API call and return response
            return await restClient.ExecutePostAsync<TokenModel>(request);
        }
    }
}
