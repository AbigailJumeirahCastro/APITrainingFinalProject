using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project2_RestSharpLibrary.Helpers;
using System.Net;

namespace Project2_RestSharpLibrary.Tests
{
    [TestClass]
    public class NegativeTests : BaseTest
    {
        [TestMethod]
        public async Task TestGetInvalidBooking()
        {
            // Get booking details
            var getBookingResponse = await BookingHelper.GetBooking(restClient, -1);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.NotFound, getBookingResponse.StatusCode, "Status code is not equal to 404");
        }
    }
}
