using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Controllers.Parameters;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest_Test
{
    [TestFixture]
    public class TaxuallyXmlClientTests
    {
        [Test]
        public void GetProcessedDataTest()
        {
            var client = TaxuallyClientFactory.GetInstance<TaxuallyQueueXmlClient>();
            var company = new Company() { CompanyId = "TestId", CompanyName = "TestName" };
            var vat = new VatRegistrationRequest() { Company = company, Country = "country_test" };

            var result = client.GetProcessedData(vat);

            Assert.AreEqual(result, "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<VatRegistrationRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Company>\r\n    <CompanyName>TestName</CompanyName>\r\n    <CompanyId>TestId</CompanyId>\r\n  </Company>\r\n  <Country>country_test</Country>\r\n</VatRegistrationRequest>");
        }
    }
}
