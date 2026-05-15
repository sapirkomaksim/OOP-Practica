using System.Collections.Generic;
using System.Linq;
using TravelAgency.Domain;

namespace TravelAgency.App
{
    // Клас для методів-розширень має бути static
    public static class TourExtensions
    {
        // Цей метод додасть нову суперздібність будь-якому списку турів.
        // Ключове слово "this" каже: "Цей метод застосовується до колекції турів".
        public static IEnumerable<Tour> GetCheapTours(this IEnumerable<Tour> tours, decimal maxPrice)
        {
            // .Where - це LINQ-команда, яка фільтрує дані
            return tours.Where(t => t.BasePrice <= maxPrice);
        }
    }
}