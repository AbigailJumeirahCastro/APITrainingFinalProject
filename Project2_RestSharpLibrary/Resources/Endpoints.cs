namespace Project2_RestSharpLibrary.Resources
{
    public class Endpoints
    {
        public static readonly string BaseURL = "https://restful-booker.herokuapp.com/";
        public static readonly string BookingEndpoint = "booking";
        public static readonly string AuthEndpoint = "auth";
        public static string CreateTokenEndpoint() => $"{BaseURL}{AuthEndpoint}";
        public static string GetBookingIdsEndpoint() => $"{BaseURL}{BookingEndpoint}";
        public static string GetBookingEndpoint(long id) => $"{BaseURL}{BookingEndpoint}/{id}";
        public static string CreateBookingEndpoint() => $"{BaseURL}{BookingEndpoint}";
        public static string UpdateBookingEndpoint(long id) => $"{BaseURL}{BookingEndpoint}/{id}";
        public static string DeleteBookingEndpoint(long id) => $"{BaseURL}{BookingEndpoint}/{id}";
    }
}
