using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1_HTTPClientLibrary.Helpers;
using System.Net;

namespace Project1_HTTPClientLibrary.Tests
{
    [TestClass]
    public class NegativeTests : BaseTest
    {
        [TestMethod]
        public async Task TestGetInvalidBooking()
        {
            // Get booking details
            var getBookingResponse = await BookingHelper.GetBooking(httpClient, -1);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.NotFound, getBookingResponse.StatusCode, "Status code is not equal to 404");
        }
    }
}
