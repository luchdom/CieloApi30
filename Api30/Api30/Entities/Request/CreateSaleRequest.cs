using Api30.Lib;
using System.Threading.Tasks;

namespace Api30.Entities.Request
{
    public class CreateSaleRequest : AbstractRequest<Sale>
    {
        public CreateSaleRequest(Merchant merchant, Environment environment)
            : base(merchant, environment)
        {
        }

        public override async Task<Sale> ExecuteAsync(Sale param)
        {
            var url = Environment.ApiUrl + "1/Sales/";
            var response = await SendRequestAsync(HttpMethodType.POST, url, param);
            return await ReadResponseAsync(response);
        }
    }
}