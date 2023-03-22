using Newtonsoft.Json;

namespace Project1_HTTPClientLibrary.DataModels
{
    public class BookingDatesModel
    {
        [JsonProperty("checkin")]
        public DateTimeOffset CheckIn { get; set; }

        [JsonProperty("checkout")]
        public DateTimeOffset CheckOut { get; set; }
    }
}
