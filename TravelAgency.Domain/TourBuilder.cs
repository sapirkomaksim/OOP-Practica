using System;

namespace TravelAgency.Domain
{
    public class TourBuilder
    {
        private Tour _tour;

        public TourBuilder(string tourName)
        {
            _tour = new Tour(tourName);
        }

        public TourBuilder SetPrice(decimal price)
        {
            _tour.BasePrice = price;
            return this;
        }

        public TourBuilder AddHotel(string hotelName)
        {
            _tour.HotelName = hotelName;
            return this;
        }

        public TourBuilder AddFlight(string flightDetails)
        {
            _tour.FlightDetails = flightDetails;
            return this;
        }

        public TourBuilder IncludeExcursions()
        {
            _tour.HasExcursions = true;
            return this;
        }

        public Tour Build()
        {
            return _tour;
        }
    }
}