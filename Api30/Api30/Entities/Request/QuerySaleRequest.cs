using Api30.Lib;
using System.Threading.Tasks;

namespace Api30.Entities.Request
{
    public class QuerySaleRequest : AbstractRequest<string>
    {
        public QuerySaleRequest(Merchant merchant, Environment environment)
            : base(merchant, environment)
        {
        }

        public override async Task<Sale> ExecuteAsync(string paymentId)
        {
            string url = Environment.ApiQueryUrl + "1/sales/" + paymentId;

            var response = await SendRequestAsync(HttpMethodType.GET, url);

            return await ReadResponseAsync(response);
        }
    }
}