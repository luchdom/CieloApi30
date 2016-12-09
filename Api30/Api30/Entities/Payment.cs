using Api30.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api30.Entities
{
    public class Payment
    {
        [JsonProperty(PropertyName = "ServiceTaxAmount")]
        public decimal ServiceTaxAmount { get; set; }

        [JsonProperty(PropertyName = "Installments")]
        public int Installments { get; set; }

        [JsonProperty(PropertyName = "Interest")]
        public string Interest { get; set; }

        [JsonProperty(PropertyName = "Capture")]
        public bool Capture { get; set; }

        [JsonProperty(PropertyName = "Authenticate")]
        public bool Authenticate { get; set; }

        [JsonProperty(PropertyName = "Recurrent")]
        public bool Recurrent { get; set; }

        [JsonProperty(PropertyName = "RecurrentPayment")]
        public RecurrentPayment RecurrentPayment { get; set; }

        [JsonProperty(PropertyName = "CreditCard")]
        public CreditCard CreditCard { get; set; }

        [JsonProperty(PropertyName = "Tid")]
        public string Tid { get; set; }

        [JsonProperty(PropertyName = "ProofOfSale")]
        public string ProofOfSale { get; set; }

        [JsonProperty(PropertyName = "AuthorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonProperty(PropertyName = "SoftDescriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty(PropertyName = "ReturnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty(PropertyName = "Provider")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Provider Provider { get; set; }

        [JsonProperty(PropertyName = "PaymentId")]
        public string PaymentId { get; set; }

        [JsonProperty(PropertyName = "Type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CieloPaymentType Type { get; set; }

        [JsonProperty(PropertyName = "Amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "ReceiveDate")]
        public string ReceiveDate { get; set; }

        [JsonProperty(PropertyName = "CapturedAmount")]
        public decimal CapturedAmount { get; set; }

        [JsonProperty(PropertyName = "CapturedDate")]
        public string CapturedDate { get; set; }

        [JsonProperty(PropertyName = "Currency")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CieloCurrency Currency { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "ReturnCode")]
        public string ReturnCode { get; set; }

        [JsonProperty(PropertyName = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public CieloPaymentStatus Status { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public object[] Links { get; set; }

        [JsonProperty(PropertyName = "ExtraDataCollection")]
        public object[] ExtraDataCollection { get; set; }

        [JsonProperty(PropertyName = "ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "BarCodeNumber")]
        public string BarCodeNumber { get; set; }

        [JsonProperty(PropertyName = "DigitableLine")]
        public string DigitableLine { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "ReasonCode")]
        public int ReasonCode { get; set; }

        [JsonProperty(PropertyName = "ReasonMessage")]
        public string ReasonMessage { get; set; }

        [JsonProperty(PropertyName = "ProviderReturnCode")]
        public string ProviderReturnCode { get; set; }

        [JsonProperty(PropertyName = "ProviderReturnMessage")]
        public string ProviderReturnMessage { get; set; }


    }
}