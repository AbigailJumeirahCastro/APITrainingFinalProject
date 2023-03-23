using Newtonsoft.Json;

namespace Project2_RestSharpLibrary.DataModels
{
    public class BookingIDModel
    {
        [JsonProperty("bookingid")]
        public long Id { get; set; }
    }
}
