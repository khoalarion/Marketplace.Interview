﻿using System.Linq;

namespace Marketplace.Interview.Business.Basket
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(Basket basket);
    }

    public class ShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShipping(Basket basket)
        {
            foreach (var lineItem in basket.LineItems)
            {
                lineItem.ShippingDescription = lineItem.Shipping.GetDescription(lineItem, basket);
            }

            return basket.LineItems.Sum(li => li.ShippingAmount);
        }
    }
}