using Project1_HTTPClientLibrary.DataModels;

namespace Project1_HTTPClientLibrary.Tests.TestData
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
