namespace ServiceContrcts {
    public interface IFinhubService {
        Task<Dictionary<string, object>?> GetCompanyProfile(string? stockSymbol);
        Task<Dictionary<string, object>?> GetStockPriceQuote(string? stockSymbol);
    }
}