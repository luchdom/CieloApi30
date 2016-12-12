using Newtonsoft.Json;

namespace Api30.Entities
{
    public class Sale
    {
        public Sale()
        {

        }
        public Sale(string merchantOrderId)
        {
            MerchantOrderId = merchantOrderId;
        }
        [JsonProperty(PropertyName = "MerchantOrderId")]
        public string MerchantOrderId { get; set; }

        [JsonProperty(PropertyName = "Customer")]
        public Customer Customer { get; set; }

        [JsonProperty(PropertyName = "Payment")]
        public Payment Payment { get; set; }

        //[JsonProperty(PropertyName = "Name")]
        //public string Name { get; set; }
    }
}