using CIServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]

namespace Project3_SOAPAPI.Tests
{
    [TestClass]
    public class SOAPTests
    {
        public CountryInfoServiceSoapTypeClient ciSoapClient { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ciSoapClient = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void TestFullCountryInfo()
        {
            // Get info of a random country
            List<tCountryCodeAndName> countryList = getListOfCountryNamesByCode();
            tCountryCodeAndName randomCountry = getRandomRecordFromList(countryList);
            tCountryInfo countryInfo = ciSoapClient.FullCountryInfo(randomCountry.sISOCode);

            // Assert values
            Assert.AreEqual(randomCountry.sISOCode, countryInfo.sISOCode, "The country codes did not match.");
            Assert.AreEqual(randomCountry.sName, countryInfo.sName, "The country names did not match.");
        }

        [TestMethod]
        public void TestCountryISOCode()
        {
            // Get country list
            List<tCountryCodeAndName> countryList = getListOfCountryNamesByCode();

            // Get random countries
            List<tCountryCodeAndName> newCountryList = new List<tCountryCodeAndName>();
            int newCountryListCount = 5;

            while (newCountryList.Count <= newCountryListCount)
            {
                var randomCountry = getRandomRecordFromList(countryList);
                bool countryExists = false;

                foreach(tCountryCodeAndName country in newCountryList)
                    if (country == randomCountry)
                        countryExists = true;

                if (!countryExists)
                    newCountryList.Add(randomCountry);
            }

            // Assert country codes of each record
            foreach (var country in newCountryList)
            {
                string isoCode = ciSoapClient.CountryISOCode(country.sName);
                Assert.AreEqual(country.sISOCode, isoCode, $"The country codes for '{country.sName}' did not match.");
            }

        }

        /// <summary> Make request to get list of country names by code </summary>
        private List<tCountryCodeAndName> getListOfCountryNamesByCode()
        {
            return ciSoapClient.ListOfCountryNamesByCode();
        }

        /// <summary> Make request to get random record from countryList </summary>
        private tCountryCodeAndName getRandomRecordFromList(List<tCountryCodeAndName> countryList)
        {
            Random random = new Random();
            var randomAddress = random.Next(0, countryList.Count);
            return countryList[randomAddress];
        }
    }
}
