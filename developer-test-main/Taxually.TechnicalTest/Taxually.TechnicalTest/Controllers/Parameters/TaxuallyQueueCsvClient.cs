using System.Text;
using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters {
    public class TaxuallyQueueCsvClient : TaxuallyQueueClient, ITaxuallyClient<byte[]> {
        public byte[] GetProcessedData (VatRegistrationRequest vat) {
            var csvBuilder = new StringBuilder ();
            csvBuilder.AppendLine ("CompanyName,CompanyId");
            csvBuilder.AppendLine ($"{vat.Company.CompanyName}{vat.Company.CompanyId}");
            return Encoding.UTF8.GetBytes (csvBuilder.ToString ());
        }

        public Task Process (string target, byte[] parameter) {
            return EnqueueAsync (target, parameter);
        }
    }
}