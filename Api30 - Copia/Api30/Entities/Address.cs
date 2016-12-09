using Newtonsoft.Json;

namespace Api30.Entities
{
    public class Address
    {
        [JsonProperty(PropertyName = "Street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "Complement")]
        public string Complement { get; set; }

        [JsonProperty(PropertyName = "ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }
    }
}