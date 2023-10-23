using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceContrcts;
using ServiceContrcts.DTO;

namespace Services {
    public class StockService : IStockService {

        private readonly List<BuyOrder> buyOrders;

        public StockService() {
            buyOrders = new List<BuyOrder>();
        }

        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest) {
            if (buyOrderRequest is null) throw new ArgumentNullException();
            ValidationContext validationContext = new ValidationContext(buyOrderRequest);
            bool isValid = Validator.TryValidateObject(buyOrderRequest, validationContext, null, true);
            if (!isValid) throw new ArgumentException();
            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
            buyOrder.BuyOrderId = Guid.NewGuid();
            buyOrders.Add(buyOrder);
            return buyOrder.ToBuyOrderResponse();
        }

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest) {
            throw new NotImplementedException();
        }

        public Task<List<BuyOrderResponse>> GetBuyOrders() {
            throw new NotImplementedException();
        }

        public Task<List<SellOrderResponse>> GetSellOrders() {
            throw new NotImplementedException();
        }
    }
}
