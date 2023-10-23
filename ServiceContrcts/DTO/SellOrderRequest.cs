using System;

namespace ServiceContrcts.DTO {

    public class SellOrderRequest {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }



}