using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceContrcts;
using System.Text.Json;

namespace Services {
    public class FinhubService : IFinhubService {
        private readonly IOptions<FinhubApiOptions> _finhubApiOptions;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public FinhubService(IOptions<FinhubApiOptions> options, IHttpClientFactory httpClientFactory, IConfiguration configuration) {
            _finhubApiOptions = options;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string? stockSymbol) {
            if (stockSymbol is null) stockSymbol = _finhubApiOptions.Value.DefaultStockSymbol;

            using(var httpClient = _httpClientFactory.CreateClient()) {
                var httpRequestMessage = new HttpRequestMessage() {
                    RequestUri = new Uri(uriString: $"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["token"]}"),
                    Method = HttpMethod.Get
                };
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                StreamReader streamReader = new StreamReader(httpResponseMessage.Content.ReadAsStream());
                string response = await streamReader.ReadToEndAsync();
                Dictionary<string, object>? companyProfile = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                return companyProfile;
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string? stockSymbol) {
            if (stockSymbol is null) stockSymbol = _finhubApiOptions.Value.DefaultStockSymbol;

            using (var httpClient = _httpClientFactory.CreateClient()) {
                var httpRequestMessage = new HttpRequestMessage() {
                    RequestUri = new Uri(uriString: $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["token"]}"),
                    Method = HttpMethod.Get
                };
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                StreamReader streamReader = new StreamReader(httpResponseMessage.Content.ReadAsStream());
                string response = await streamReader.ReadToEndAsync();
                Dictionary<string, object>? stockPrice = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                return stockPrice;
            }
        }
    }
}