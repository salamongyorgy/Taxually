using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters {
    public class TaxuallyHttpClient : TaxuallyAbbstractClient<VatRegistrationRequest> {
        public override VatRegistrationRequest GetProcessedData (VatRegistrationRequest vat) {
            return vat;
        }

        public override Task Process (string target, VatRegistrationRequest parameter) {
            return PostAsync (target, parameter);
        }

        private Task PostAsync<TRequest> (string url, TRequest request) {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}