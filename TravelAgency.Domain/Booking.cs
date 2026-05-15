using System;

namespace TravelAgency.Domain
{
    public class Booking
    {
        public Tour Tour { get; set; }
        private IPricingStrategy _pricingStrategy;

        public Booking(Tour tour, IPricingStrategy pricingStrategy)
        {
            Tour = tour;
            _pricingStrategy = pricingStrategy;
        }

        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            _pricingStrategy = strategy;
        }

        public decimal GetFinalPrice()
        {
            return _pricingStrategy.Calculate(Tour.BasePrice);
        }
    }
}