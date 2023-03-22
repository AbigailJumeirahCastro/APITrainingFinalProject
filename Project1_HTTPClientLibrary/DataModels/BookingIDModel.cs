using Newtonsoft.Json;

namespace Project1_HTTPClientLibrary.DataModels
{
    public class BookingIDModel
    {
        [JsonProperty("bookingid")]
        public long Id { get; set; }
    }
}
