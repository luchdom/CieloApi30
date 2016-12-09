using Api30.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api30.Entities
{
    public class CreditCard
    {
        public CreditCard(string holder, string expirationDate, string cardNumber, string securityCode, string brand)
        {
            SaveCard = false;
            Holder = holder;
            ExpirationDate = expirationDate;
            CardNumber = cardNumber;
            SecurityCode = securityCode;
            Brand = brand;
        }

        [JsonProperty(PropertyName = "CardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty(PropertyName = "Holder")]
        public string Holder { get; set; }

        [JsonProperty(PropertyName = "ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "SecurityCode")]
        public string SecurityCode { get; set; }

        [JsonProperty(PropertyName = "SaveCard")]
        public bool SaveCard { get; set; }

        [JsonProperty(PropertyName = "Brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "CardToken")]
        public string CardToken { get; set; }
    }
}