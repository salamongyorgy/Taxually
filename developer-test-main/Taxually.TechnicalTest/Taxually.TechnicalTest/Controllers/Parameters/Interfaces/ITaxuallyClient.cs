using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters.Interfaces
{
    public interface ITaxuallyClient<TParameter>
    {
        Task Process(string target, TParameter parameter);

        TParameter GetProcessedData(VatRegistrationRequest vat);
    }
}
