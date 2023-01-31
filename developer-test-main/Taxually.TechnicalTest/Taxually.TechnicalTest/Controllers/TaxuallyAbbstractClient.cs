using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers
{
    public abstract class TaxuallyAbbstractClient<T> :  ITaxuallyClient<T>
    {
        public abstract T GetProcessedData(VatRegistrationRequest vat);
        public abstract Task Process(string target, T parameter);
    }
}
