using System.Xml.Serialization;
using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters
{
    public class TaxuallyQueueXmlClient : TaxuallyQueueClient, ITaxuallyClient<string>
    { 
        private string xml = string.Empty;

        public string GetProcessedData(VatRegistrationRequest vat)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, vat);
                xml = stringwriter.ToString();
            }
            return xml;
        }

        public Task Process(string target, string parameter)
        {
            return EnqueueAsync(target, parameter);
        }
    }
}
