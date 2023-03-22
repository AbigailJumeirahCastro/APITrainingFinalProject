using Project1_HTTPClientLibrary.DataModels;

namespace Project1_HTTPClientLibrary.Tests.TestData
{
    public class GenerateBooking
    {
        public static BookingDetailsModel booking()
        {
            BookingDatesModel bookingDatesData = new BookingDatesModel()
            {
                CheckIn = DateTime.Today.AddDays(1),
                CheckOut = DateTime.Today.AddDays(7)
            };

            return new BookingDetailsModel()
            {
                FirstName = "AJ",
                LastName = "Castro",
                TotalPrice = 100,
                DepositPaid = true,
                BookingDates = bookingDatesData,
                AdditionalNeeds = "None"
            };
        }
    }
}
