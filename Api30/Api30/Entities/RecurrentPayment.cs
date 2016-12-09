using Newtonsoft.Json;
using System;

namespace Api30.Entities
{
    public class RecurrentPayment
    {
        [JsonProperty(PropertyName = "AuthorizeNow")]
        private bool AuthorizeNow { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        private DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "EndDate")]
        private DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "Interval")]
        private string Interval { get; set; }
    }
}