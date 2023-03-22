using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]

namespace Project1_HTTPClientLibrary.Tests
{

    public class BaseTest
    {
        public static HttpClient httpClient { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }

}
