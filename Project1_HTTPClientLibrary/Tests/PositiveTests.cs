﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project1_HTTPClientLibrary.DataModels;
using Project1_HTTPClientLibrary.Helpers;
using Project1_HTTPClientLibrary.Resources;
using System.Net;

namespace Project1_HTTPClientLibrary.Tests
{
    [TestClass]
    public class PositiveTests : BaseTest
    {
        private List<BookingModel> cleanUpList = new List<BookingModel>();

        [TestCleanup]
        public async Task TestCleanup()
        {
            // Delete created data
            foreach (var data in cleanUpList)
                await BookingHelper.DeleteBooking(httpClient, data.BookingId);
        }

        [TestMethod]
        public async Task TestBookingCreation()
        {
            // Create booking
            var createBookingResponse = await BookingHelper.CreateBooking(httpClient);
            var createBookingResponseData = JsonConvert.DeserializeObject<BookingModel>(createBookingResponse.Content.ReadAsStringAsync().Result);
            cleanUpList.Add(createBookingResponseData);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.OK, createBookingResponse.StatusCode, "Status code is not equal to 200");

            // Get booking details
            var getBookingResponse = await BookingHelper.GetBooking(httpClient, createBookingResponseData.BookingId);
            var getBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(getBookingResponse.Content.ReadAsStringAsync().Result);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.OK, getBookingResponse.StatusCode, "Status code is not equal to 200");

            // Assert response values
            Assert.AreEqual(createBookingResponseData.BookingDetails.FirstName, getBookingResponseData.FirstName, "firstname did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.LastName, getBookingResponseData.LastName, "lastname did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.TotalPrice, getBookingResponseData.TotalPrice, "totalprice did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.DepositPaid, getBookingResponseData.DepositPaid, "depositpaid did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.BookingDates.CheckIn, getBookingResponseData.BookingDates.CheckIn, "bookingdates (checkin) did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.BookingDates.CheckOut, getBookingResponseData.BookingDates.CheckOut, "bookingdates (checkout) did not match.");
            Assert.AreEqual(createBookingResponseData.BookingDetails.AdditionalNeeds, getBookingResponseData.AdditionalNeeds, "additionalneeds did not match.");
        }

        [TestMethod]
        public async Task TestBookingUpdate()
        {
            // Get list of booking IDs
            var getBookingIDsResponse = await BookingHelper.GetBookingIDs(httpClient);
            var getBookingIDsResponseData = JsonConvert.DeserializeObject<List<BookingIDModel>>(getBookingIDsResponse.Content.ReadAsStringAsync().Result);

            // Proceed if there are existing bookings
            if (getBookingIDsResponseData.Count > 0)
            {
                // Get random ID from the list
                Random random = new Random();
                var randomAddress = random.Next(0, getBookingIDsResponseData.Count);
                var randomID = getBookingIDsResponseData[randomAddress].Id;

                // Update booking
                var updateBookingResponse = await BookingHelper.UpdateBooking(httpClient, randomID);
                var updateBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(updateBookingResponse.Content.ReadAsStringAsync().Result);

                // Assert status code
                Assert.AreEqual(HttpStatusCode.OK, updateBookingResponse.StatusCode, "Status code is not equal to 200");

                // Get booking details
                var getBookingResponse = await BookingHelper.GetBooking(httpClient, randomID);
                var getBookingResponseData = JsonConvert.DeserializeObject<BookingDetailsModel>(getBookingResponse.Content.ReadAsStringAsync().Result);

                // Assert status code
                Assert.AreEqual(HttpStatusCode.OK, getBookingResponse.StatusCode, "Status code is not equal to 200");

                // Assert response values
                Assert.AreEqual(updateBookingResponseData.FirstName, getBookingResponseData.FirstName, "firstname did not match.");
                Assert.AreEqual(updateBookingResponseData.LastName, getBookingResponseData.LastName, "lastname did not match.");
                Assert.AreEqual(updateBookingResponseData.TotalPrice, getBookingResponseData.TotalPrice, "totalprice did not match.");
                Assert.AreEqual(updateBookingResponseData.DepositPaid, getBookingResponseData.DepositPaid, "depositpaid did not match.");
                Assert.AreEqual(updateBookingResponseData.BookingDates.CheckIn, getBookingResponseData.BookingDates.CheckIn, "bookingdates (checkin) did not match.");
                Assert.AreEqual(updateBookingResponseData.BookingDates.CheckOut, getBookingResponseData.BookingDates.CheckOut, "bookingdates (checkout) did not match.");
                Assert.AreEqual(updateBookingResponseData.AdditionalNeeds, getBookingResponseData.AdditionalNeeds, "additionalneeds did not match.");
            }
            else
                Console.WriteLine("There are no bookings to update.");
        }

        [TestMethod]
        public async Task TestBookingDeletion()
        {
            // Create booking
            var createBookingResponse = await BookingHelper.CreateBooking(httpClient);
            var createBookingResponseData = JsonConvert.DeserializeObject<BookingModel>(createBookingResponse.Content.ReadAsStringAsync().Result);

            // Delete booking
            var deleteBookingResponse = await BookingHelper.DeleteBooking(httpClient, createBookingResponseData.BookingId);

            // Assert status code
            Assert.AreEqual(HttpStatusCode.Created, deleteBookingResponse.StatusCode, "Status code is not equal to 201");
        }
    }
}
