using ServiceContrcts;
using ServiceContrcts.DTO;
using Services;
using System;
using Xunit;

namespace XUnit_Task_Tests {
    public class StockServiceTests {

        private readonly IStockService _stockService;

        public StockServiceTests() {
            _stockService = new StockService();
        }

        [Fact]
        public void CreateBuyOrder_NullBuyOrderRequest_ArgumnetNullException() {
            Assert.Throws<ArgumentNullException>(() => {
                _stockService.CreateBuyOrder(null);
            });
        }

        [Fact]

        public  void CreateBuyOrder_NonValidStockSymbol_ArgumentException() {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest() {
                StockSymbol = null,
                StockName = "microsoft",
                Price = 150,
                Quantity = 15,
                DateTimeOfOrder = DateTime.Today
            };
            Assert.Throws<ArgumentException>(() => {
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]

        public void CreateBuyOrder_NonValidPrice_ArgumentException() {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest() {
                StockSymbol = "mstf",
                Price = -150,
                Quantity = 15,
                DateTimeOfOrder = DateTime.Today
            };
            Assert.Throws<ArgumentException>(() => {
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
            Assert.Throws<ArgumentException>(() => {
                buyOrderRequest.Price = 100005;
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]

        public void CreateBuyOrder_NonValidQuantity_ArgumentException() {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest() {
                StockSymbol = "mstf",
                Price = 10,
                Quantity = -15,
                DateTimeOfOrder = DateTime.Today
            };
            Assert.Throws<ArgumentException>(() => {
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
            Assert.Throws<ArgumentException>(() => {
                buyOrderRequest.Quantity = 100005;
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]

        public void CreateBuyOrder_NonValidOrderDate_ArgumentException() {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest() {
                StockSymbol = "mstf",
                Price = 10,
                Quantity = 15,
                DateTimeOfOrder = DateTime.Parse("1998-01-01")
            };
            Assert.Throws<ArgumentException>(() => {
                _stockService.CreateBuyOrder(buyOrderRequest);
            });
            
        }

        [Fact]
        public void CreateBuyOrder_ValidInputs_ResponseWithGuid() {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest() {
                StockSymbol = "mstf",
                Price = 10,
                Quantity = 15,
                DateTimeOfOrder = DateTime.Now
            };

            BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(buyOrderRequest);
            Assert.True(buyOrderResponse.BuyOrderId != Guid.Empty);
        }
    }
}