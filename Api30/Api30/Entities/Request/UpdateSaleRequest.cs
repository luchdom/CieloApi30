using Api30.Lib;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api30.Entities.Request
{
    public class UpdateSaleRequest : AbstractRequest<string>
    {
        private string _type { get; set; }
        public decimal? Amount { get; set; }
        public decimal? ServiceTaxAmount { get; set; }

        public UpdateSaleRequest(string type, Merchant merchant, Environment environment)
            : base(merchant, environment)
        {
            _type = type;
        }

        public override async Task<Sale> ExecuteAsync(string paymentId)
        {
            //Sale sale = null;
            var url = Environment.ApiUrl + "1/sales/" + paymentId + "/" + _type;
            var queryParams = new Dictionary<string, string>();

            if (Amount.HasValue)
            {
                queryParams.Add("amount", Amount.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }

            if (ServiceTaxAmount.HasValue)
            {
                queryParams.Add("serviceTaxAmount", ServiceTaxAmount.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            if (queryParams.Any())
                url = url + await (new FormUrlEncodedContent(queryParams)).ReadAsStringAsync();

            var response = await SendRequestAsync(HttpMethodType.PUT, url);
            return await ReadResponseAsync(response);
        }
    }
}