using Microsoft.AspNetCore.Mvc;
using ServiceContrcts;

namespace StockMarket.Controllers {
    public class FunhubApiController : Controller {
        private readonly IFinhubService _finhubService;
        public FunhubApiController(IFinhubService finhubService) {
            _finhubService = finhubService;
        }

        [Route("/company-profile/{stockName?}")]
        public async Task<IActionResult> CompanyProfile(string? stockName) {
            var res = await _finhubService.GetCompanyProfile(stockName);
            return Json(res);
        }

        [Route("/stock-quote/{stockName?}")]
        public async Task<IActionResult> StockQuote(string? stockName) {
            var res = await _finhubService.GetStockPriceQuote(stockName);
            return Json(res);
        }
    }
}
