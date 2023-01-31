using NUnit.Framework;
using Taxually.TechnicalTest.Controllers.Parameters;
using Taxually.TechnicalTest.Model;
using System.Text;
using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest_Test
{
    [TestFixture]
    public class TaxuallyCsvClientTests
    {

        [Test]
        public void GetProcessedDataTest()
        {
            var client = TaxuallyClientFactory.GetInstance<TaxuallyQueueCsvClient>();
            var company = new Company() { CompanyId = "TestId", CompanyName = "TestName" };
            var vat = new VatRegistrationRequest() { Company = company, Country = "country_test" };

            var result = client.GetProcessedData(vat);

            Assert.AreEqual(Encoding.UTF8.GetString(result), "CompanyName,CompanyId\r\nTestNameTestId\r\n");
        }

    }
}