using Newtonsoft.Json;

namespace Api30.Entities
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "BirthDate")]
        public string BirthDate { get; set; }

        [JsonProperty(PropertyName = "Identity")]
        public string Identity { get; set; }

        [JsonProperty(PropertyName = "IdentityType")]
        public string IdentityType { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "DeliveryAddress")]
        public Address DeliveryAddress { get; set; }
    }
}