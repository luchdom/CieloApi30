using Api30.Entities;
using Api30.Entities.Request;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api30.Services
{
    public class CieloEcommerceService
    {
        private Environment _environment;
        private Merchant _merchant;
        private HttpClient _httpClient;

        public CieloEcommerceService(Merchant merchant, Environment environment)
        {
            _environment = environment;
            _merchant = merchant;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            var createSaleRequest = new CreateSaleRequest(_merchant, _environment);
            return await createSaleRequest.ExecuteAsync(sale);
        }

        public async Task<Sale> QuerySaleAsync(string paymentId)
        {
            var querySaleRequest = new QuerySaleRequest(_merchant, _environment);
            return await querySaleRequest.ExecuteAsync(paymentId);
        }

        public async Task<Sale> CancelSaleAsync(string paymentId, double? amount = null)
        {
            var updateSaleRequest = new UpdateSaleRequest("void", _merchant, _environment);
            return await updateSaleRequest.ExecuteAsync(paymentId);
        }

        //public async Task<Sale> CancelSale(string paymentId)
        //{
        //    return await CancelSale(paymentId);
        //}

        public async Task<Sale> CaptureSaleAsync(string paymentId, decimal? amount = null, decimal? serviceTaxAmount = null)
        {
            var updateSaleRequest = new UpdateSaleRequest("capture", _merchant, _environment);
            updateSaleRequest.Amount = amount;
            updateSaleRequest.ServiceTaxAmount = serviceTaxAmount;

            return await updateSaleRequest.ExecuteAsync(paymentId);
        }

        //public async Task<Sale> CaptureSale(string paymentId, decimal amount)
        //{
        //    return await CaptureSale(paymentId, amount);
        //}

        //public async Task<Sale> CaptureSale(string paymentId)
        //{
        //    return await CaptureSale(paymentId);
        //}
    }
}