using Api30.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api30.Entities
{
    public class CreditCard
    {
        public CreditCard()
        {
            SaveCard = false;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public CieloCardBrand Brand { get; set; }

        [JsonProperty(PropertyName = "CardToken")]
        public string CardToken { get; set; }
    }
}