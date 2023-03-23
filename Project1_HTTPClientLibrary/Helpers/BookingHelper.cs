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
        /// <summary> Make POST request to create new booking </summary>
        public static async Task<HttpResponseMessage> CreateBooking(HttpClient httpClient)
        {
            // Create data
            var booking = GenerateBooking.booking();

            // Create request
            var request = JsonConvert.SerializeObject(booking);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make API call and return response
            return await httpClient.PostAsync(Endpoints.CreateBookingEndpoint(), content);
        }

        /// <summary> Make GET request to find booking by ID </summary>
        public static async Task<HttpResponseMessage> GetBooking(HttpClient httpClient, long id)
        {
            // Make API call and return response
            return await httpClient.GetAsync(Endpoints.GetBookingEndpoint(id));
        }

        /// <summary> Make GET request to get list of booking IDs </summary>
        public static async Task<HttpResponseMessage> GetBookingIDs(HttpClient httpClient)
        {
            // Make API call and return response
            return await httpClient.GetAsync(Endpoints.GetBookingIdsEndpoint());
        }

        /// <summary> Make PUT request to update booking </summary>
        public static async Task<HttpResponseMessage> UpdateBooking(HttpClient httpClient, long id)
        {
            // Get booking details
            var getBookingResponse = await GetBooking(httpClient, id);
            var getBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(getBookingResponse.Content.ReadAsStringAsync().Result);

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
            var request = JsonConvert.SerializeObject(newBookingDetails);
            HttpContent content = new StringContent(request, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Make API call and return response
            return await httpClient.PutAsync(Endpoints.UpdateBookingEndpoint(id), content);
        }

        /// <summary> Make DELETE request to delete booking </summary>
        public static async Task<HttpResponseMessage> DeleteBooking(HttpClient httpClient, long id)
        {
            // Make API call and return response
            return await httpClient.DeleteAsync(Endpoints.DeleteBookingEndpoint(id));
        }
    }
}
