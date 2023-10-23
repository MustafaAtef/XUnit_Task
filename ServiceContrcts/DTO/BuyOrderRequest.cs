using Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceContrcts.DTO {

    public class BuyOrderRequest: IValidatableObject {

        [Required]
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        [Range(1, 100000)]
        public int Quantity { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            BuyOrderRequest buyOrderRequest = validationContext.ObjectInstance as BuyOrderRequest;
            if (buyOrderRequest.DateTimeOfOrder < DateTime.Parse("2000-01-01")) yield return new ValidationResult("Date of the order must be newer than 2000-01-01");
            else yield return ValidationResult.Success;
        }

        public BuyOrder ToBuyOrder() {
            return new() { DateTimeOfOrder = this.DateTimeOfOrder, Price = this.Price, Quantity = this.Quantity, StockName = this.StockName, StockSymbol = this.StockSymbol };
        }
    }



}