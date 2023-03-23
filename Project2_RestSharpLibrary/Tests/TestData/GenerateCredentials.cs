using Project2_RestSharpLibrary.DataModels;

namespace Project2_RestSharpLibrary.Tests.TestData
{
    public class GenerateCredentials
    {
        public static AuthCredentialsModel credentials()
        {

            return new AuthCredentialsModel()
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
