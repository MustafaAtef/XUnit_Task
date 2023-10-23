using Entities;
using System;

namespace ServiceContrcts.DTO {

    public class BuyOrderResponse {
        public Guid? BuyOrderId { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }
    }


    public static class BuyOrderExtensions {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder ) {
            return new() { BuyOrderId = buyOrder.BuyOrderId, DateTimeOfOrder = buyOrder.DateTimeOfOrder, Price = buyOrder.Price, Quantity = buyOrder.Quantity, StockName = buyOrder.StockName, StockSymbol = buyOrder.StockSymbol, TradeAmount = buyOrder.Price * buyOrder.Quantity };
        }
    }


}