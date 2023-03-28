using Store.Api.ShopinCart.Remote.Interface;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Store.Api.ShopinCart.Remote
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory HttpClient;
        private readonly ILogger<ProductService> Logger;

        public ProductService(IHttpClientFactory _httpClientFactory, ILogger<ProductService> _logger)
        {
            HttpClient = _httpClientFactory;
            Logger = _logger;
        }

        public async Task<(bool resul, Product product, string Msg)> GetProduct(int id)
        {
            try
            {
                var client = HttpClient.CreateClient("Products");
                var response = await client.GetAsync($"/api/products/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Product>(content, option);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            } catch (Exception ex) {
                Logger?.LogError(ex.ToString());
                return (false, null, ex.ToString());
            }
        }

        public async Task<(bool resul, string Msg)> SetTransactionPost(Object data, string resourceUri, string api)
        {
            try
            {
                var client = HttpClient.CreateClient(resourceUri);

                var itemJson = new StringContent(
                    JsonSerializer.Serialize(data),
                    Encoding.UTF8,
                    Application.Json);

                var httpResponseMessage = await client.PostAsync(api, itemJson);

                httpResponseMessage.EnsureSuccessStatusCode();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return (true, null);
                }

                return (false,httpResponseMessage.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex.ToString());
                return (false,ex.ToString());
            }
        }
    }
}
