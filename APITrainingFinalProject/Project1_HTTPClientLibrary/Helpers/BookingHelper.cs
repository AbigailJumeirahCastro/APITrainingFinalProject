using Newtonsoft.Json;
using Project1_HTTPClientLibrary.DataModels;
using Project1_HTTPClientLibrary.Tests.TestData;
using Project1_HTTPClientLibrary.Resources;
using System.Net.Http.Headers;
using System.Text;

namespace Project1_HTTPClientLibrary.Helpers
{
    internal class BookingHelper
    {
        /// <summary>
        /// Make POST request to create new booking
        /// </summary>

        public static async Task<HttpResponseMessage> CreateBooking(HttpClient httpClient)
        {
            // Create JSON Object
            var booking = GenerateBooking.booking();

            // Create the request content as JSON
            var request = JsonConvert.SerializeObject(booking);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");

            // Add header to the request to accept JSON content
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make POST Request
            var response = await httpClient.PostAsync(Endpoints.GetURL(Endpoints.BookingEndpoint), content);

            // Return the deserialized response data
            return response;
        }

        /// <summary>
        /// Make GET request to find booking by ID
        /// </summary>

        public static async Task<HttpResponseMessage> GetBooking(HttpClient httpClient, long id)
        {
            // Make GET request
            var response = await httpClient.GetAsync(Endpoints.GetURI($"{Endpoints.BookingEndpoint}/{id}"));

            // Return the deserialized response data
            return response;
        }

        /// <summary>
        /// Make GET request to get list of booking IDs
        /// </summary>
        public static async Task<HttpResponseMessage> GetBookingIDs(HttpClient httpClient)
        {
            // Make GET request
            var response = await httpClient.GetAsync(Endpoints.GetURI($"{Endpoints.BookingEndpoint}"));

            // Return the deserialized response data
            return response;
        }

        /// <summary>
        /// Make PUT request to update booking
        /// </summary>

        public static async Task<HttpResponseMessage> UpdateBooking(HttpClient httpClient, TokenModel token, long id)
        {
            // Get booking details
            var getBookingResponse = await GetBooking(httpClient, id);

            // Deserialize response data
            var getBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(getBookingResponse.Content.ReadAsStringAsync().Result);

            // Create JSON Object
            BookingDetailsModel newBookingDetails = new BookingDetailsModel()
            {
                FirstName = getBookingResponseData.FirstName + " Updated",
                LastName = getBookingResponseData.LastName + " Updated",
                TotalPrice = getBookingResponseData.TotalPrice,
                DepositPaid = getBookingResponseData.DepositPaid,
                BookingDates = getBookingResponseData.BookingDates,
                AdditionalNeeds = getBookingResponseData.AdditionalNeeds
            };

            // Create the request content as JSON
            var request = JsonConvert.SerializeObject(newBookingDetails);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");

            // Add header to the request to accept JSON content
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Remove existing "Cookie" header if it exists
            if (httpClient.DefaultRequestHeaders.Contains("Cookie"))
            {
                httpClient.DefaultRequestHeaders.Remove("Cookie");
            }

            // Add token header to the request
            httpClient.DefaultRequestHeaders.Add("Cookie", $"token={token.Token}");

            // Make PUT Request
            var response = await httpClient.PutAsync(Endpoints.GetURI($"{Endpoints.BookingEndpoint}/{id}"), content);

            // Return the deserialized response data
            return response;
        }

        /// <summary>
        /// Make DELETE request to delete booking
        /// </summary>

        public static async Task<HttpResponseMessage> DeleteBooking(HttpClient httpClient, TokenModel token, long id)
        {
            // Remove existing "Cookie" header if it exists
            if (httpClient.DefaultRequestHeaders.Contains("Cookie"))
            {
                httpClient.DefaultRequestHeaders.Remove("Cookie");
            }

            // Add token header to the request
            httpClient.DefaultRequestHeaders.Add("Cookie", $"token={token.Token}");

            // Make DELETE Request
            var response = await httpClient.DeleteAsync(Endpoints.GetURI($"{Endpoints.BookingEndpoint}/{id}"));

            return response;
        }
    }
}
