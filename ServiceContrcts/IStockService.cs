using ServiceContrcts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContrcts {
    public interface IStockService {
        BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);

        Task<List<BuyOrderResponse>> GetBuyOrders();

        Task<List<SellOrderResponse>> GetSellOrders();


    }
}
