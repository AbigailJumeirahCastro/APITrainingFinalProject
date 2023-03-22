namespace Project1_HTTPClientLibrary.Resources
{
    public class Endpoints
    {
        public static readonly string BaseURL = "https://restful-booker.herokuapp.com/";
        public static readonly string BookingEndpoint = "booking";
        public static readonly string AuthEndpoint = "auth";
        public static string GetURL(string endpoint) => $"{BaseURL}{endpoint}";
        public static Uri GetURI(string endpoint) => new Uri(GetURL(endpoint));
    }
}
