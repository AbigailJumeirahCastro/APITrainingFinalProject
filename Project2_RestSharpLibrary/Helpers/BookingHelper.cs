using Newtonsoft.Json;
using Project2_RestSharpLibrary.DataModels;
using Project2_RestSharpLibrary.Tests.TestData;
using Project2_RestSharpLibrary.Resources;
using System.Net.Http.Headers;
using System.Text;
using RestSharp;

namespace Project2_RestSharpLibrary.Helpers
{
    internal class BookingHelper
    {
        /// <summary> Make POST request to create new booking </summary>
        public static async Task<RestResponse> CreateBooking(RestClient restClient)
        {
            // Create data
            var booking = GenerateBooking.booking();

            // Create request
            var request = new RestRequest(Endpoints.CreateBookingEndpoint());
            request.AddJsonBody(JsonConvert.SerializeObject(booking));
            request.AddHeader("Content-Type", "application/json");

            // Make API call and return response
            return await restClient.ExecutePostAsync(request);
        }

        /// <summary> Make GET request to find booking by ID </summary>
        public static async Task<RestResponse> GetBooking(RestClient restClient, long id)
        {
            // Create request
            var request = new RestRequest(Endpoints.GetBookingEndpoint(id));

            // Make API call and return response
            return await restClient.ExecuteGetAsync(request);
        }

        /// <summary> Make GET request to get list of booking IDs </summary>
        public static async Task<RestResponse> GetBookingIDs(RestClient restClient)
        {
            // Create request
            var request = new RestRequest(Endpoints.GetBookingIdsEndpoint());

            // Make API call and return response
            return await restClient.ExecuteGetAsync(request);
        }

        /// <summary> Make PUT request to update booking </summary>
        public static async Task<RestResponse> UpdateBooking(RestClient restClient, long id)
        {
            // Get booking details
            var getBookingResponse = await GetBooking(restClient, id);
            var getBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(getBookingResponse.Content);

            // Create data
            BookingDetailsModel newBookingDetails = new BookingDetailsModel()
            {
                FirstName = getBookingResponseData.FirstName + " Updated",
                LastName = getBookingResponseData.LastName + " Updated",
                TotalPrice = getBookingResponseData.TotalPrice,
                DepositPaid = getBookingResponseData.DepositPaid,
                BookingDates = getBookingResponseData.BookingDates,
                AdditionalNeeds = getBookingResponseData.AdditionalNeeds
            };

            // Create request
            var request = new RestRequest(Endpoints.UpdateBookingEndpoint(id));
            request.AddJsonBody(JsonConvert.SerializeObject(newBookingDetails));
            request.AddHeader("Content-Type", "application/json");

            // Make API call and return response
            return await restClient.ExecutePutAsync(request);
        }


        /// <summary> Make DELETE request to delete booking </summary>
        public static async Task<RestResponse> DeleteBooking(RestClient restClient, long id)
        {
            // Create request
            var request = new RestRequest(Endpoints.DeleteBookingEndpoint(id));

            // Make API call and return response
            return await restClient.DeleteAsync(request);
        }
    }
}
