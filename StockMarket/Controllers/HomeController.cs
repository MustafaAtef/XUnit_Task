using Microsoft.AspNetCore.Mvc;
using ServiceContrcts;

namespace StockMarket.Controllers {
    public class HomeController : Controller {

        [Route("/")]
        public IActionResult Index() {
            return Content("hi");
        }
    }
}
