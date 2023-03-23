using Newtonsoft.Json;

namespace Project2_RestSharpLibrary.DataModels
{
    public class BookingModel
    {
        [JsonProperty("bookingid")]
        public long BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingDetailsModel BookingDetails { get; set; }

    }
}
