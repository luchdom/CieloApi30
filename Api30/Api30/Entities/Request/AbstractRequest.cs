using Api30.Lib;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api30.Entities.Request
{
    public abstract class AbstractRequest<T>
    {
        public readonly Environment Environment;
        private readonly Merchant _merchant;
        public HttpClient _httpClient;

        public AbstractRequest(Merchant merchant, Environment environment)
        {
            _merchant = merchant;
            Environment = environment;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            //_httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "CieloEcommerce/3.0 .NET SDK");
            _httpClient.DefaultRequestHeaders.Add("MerchantId", merchant.Id);
            _httpClient.DefaultRequestHeaders.Add("MerchantKey", merchant.Key);
            _httpClient.DefaultRequestHeaders.Add("RequestId", Guid.NewGuid().ToString());
        }

        //public void SetHttpClient(HttpClient httpClient)
        //{
        //    this._httpClient = httpClient;
        //}

        public abstract Task<Sale> ExecuteAsync(T param);

        public async Task<HttpResponseMessage> SendRequestAsync(HttpMethodType method, string url, Sale sale = null)
        {
            switch (method)
            {
                case HttpMethodType.GET:
                    return await _httpClient.GetAsync(url);

                case HttpMethodType.POST:
                    var jsonPost = JsonConvert.SerializeObject(sale, Formatting.None, new JsonSerializerSettings
                    { NullValueHandling = NullValueHandling.Ignore });
                    var contentPost = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                    return await _httpClient.PostAsync(url, contentPost);

                case HttpMethodType.PUT:
                    var json = JsonConvert.SerializeObject(sale, Formatting.None, new JsonSerializerSettings
                    { NullValueHandling = NullValueHandling.Ignore });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    return await _httpClient.PutAsync(url, content);

                default:
                    //_httpClient.SendAsync()
                    break;
            }
            return null;
        }

        public async Task<Sale> ReadResponseAsync(HttpResponseMessage response)
        {
            Sale sale = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    if(response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var result = await response.Content.ReadAsStringAsync();
            //        sale = JsonConvert.DeserializeObject<Sale>(result);
            //    }
            //}
            //else
            //{
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    var resultSuccess = await response.Content.ReadAsStringAsync();
                    sale = JsonConvert.DeserializeObject<Sale>(resultSuccess);
                    break;

                case HttpStatusCode.BadRequest:
                    CieloRequestException exception = null;
                    var result = await response.Content.ReadAsStringAsync();
                    CieloError[] errors = JsonConvert.DeserializeObject<CieloError[]>(result);
                    foreach (var error in errors)
                    {
                        Debug.WriteLine($"Cielo Error[{error.Code}] : {error.Message}");
                        exception = new CieloRequestException(error.Message, error, exception);
                    }
                    throw exception;
                case HttpStatusCode.NotFound:
                    throw new CieloRequestException("Not found", new CieloError((int)response.StatusCode, "Not found"));
                default:
                    Debug.WriteLine($"Cielo : Unknown status : {(int)response.StatusCode}");
                    break;
            }
            //}
            return sale;
        }
    }
}