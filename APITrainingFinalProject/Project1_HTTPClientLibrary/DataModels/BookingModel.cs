using Newtonsoft.Json;

namespace Project1_HTTPClientLibrary.DataModels
{
    public class BookingModel
    {
        [JsonProperty("bookingid")]
        public long BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingDetailsModel BookingDetails { get; set; }

    }
}
