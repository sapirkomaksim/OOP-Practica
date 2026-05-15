namespace TravelAgency.Domain
{
    // 1. Звичайна ціна
    public class RegularPricing : IPricingStrategy
    {
        public decimal Calculate(decimal basePrice) => basePrice;
    }

    // 2. Гаряча ціна (-20%)
    public class HotTourPricing : IPricingStrategy
    {
        public decimal Calculate(decimal basePrice) => basePrice * 0.8m;
    }
}