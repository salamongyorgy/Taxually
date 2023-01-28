using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Model;
using Taxually.TechnicalTest.Controllers.Parameters;
using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using System.Net.Sockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            switch (request.Country)
            {
                case "GB":
                    // UK has an API to register for a VAT number
                    var httpclient = TaxuallyClientFactory.GetInstance<TaxuallyHttpClient>();
                    httpclient.Process("https://api.uktax.gov.uk", httpclient.GetProcessedData(request)).Wait();
                    break;
                case "FR":
                    // France requires an excel spreadsheet to be uploaded to register for a VAT number
                    var cvsClient = TaxuallyClientFactory.GetInstance<TaxuallyQueueCsvClient>();
                    // Queue file to be processed
                    cvsClient.Process("vat-registration-csv", cvsClient.GetProcessedData(request)).Wait();
                    break;
                case "DE":
                    // Germany requires an XML document to be uploaded to register for a VAT number
                    var xmlClient = TaxuallyClientFactory.GetInstance<TaxuallyQueueXmlClient>();
                    // Queue xml doc to be processed
                    xmlClient.Process("vat-registration-xml", xmlClient.GetProcessedData(request)).Wait();
                    break;
                default:
                    return UnprocessableEntity();
            }
            return Ok();
        }
       
    }

}
