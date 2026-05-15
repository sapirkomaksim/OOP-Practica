using System;
using System.Collections.Generic;

namespace TravelAgency.Domain
{
    public class Tour
    {
        // 1. Поля (Дані нашого туру)
        public Guid Id { get; private set; }
        public string TourName { get; set; }
        public decimal BasePrice { get; set; } 
        
        // Поля для Будівельника та майбутніх завдань
        public string HotelName { get; set; }
        public string FlightDetails { get; set; }
        public bool HasExcursions { get; set; }

        // Список маршрутів всередині туру (Агрегація)
        private List<Route> _routes;

        // 2. Конструктори (Самостійна робота 1)
        public Tour(string tourName)
        {
            Id = Guid.NewGuid();
            TourName = tourName;
            _routes = new List<Route>();
        }

        // Копіювальний конструктор
        public Tour(Tour otherTour)
        {
            if (otherTour == null) throw new ArgumentNullException(nameof(otherTour));
            
            Id = Guid.NewGuid();
            TourName = otherTour.TourName;
            BasePrice = otherTour.BasePrice;
            HotelName = otherTour.HotelName;
            FlightDetails = otherTour.FlightDetails;
            HasExcursions = otherTour.HasExcursions;
            _routes = new List<Route>(otherTour._routes);
        }

        // 3. Методи роботи з даними
        public void AddRoute(Route route)
        {
            if (route == null) throw new ArgumentNullException("Маршрут не може бути порожнім!");
            _routes.Add(route);
        }

        // 4. Індексатор (Самостійна робота 2)
        // Дозволяє писати: myTour[0] щоб отримати маршрут
        public Route this[int index]
        {
            get
            {
                if (index < 0 || index >= _routes.Count) 
                    throw new IndexOutOfRangeException("Такого номера маршруту не існує!");
                return _routes[index];
            }
            set
            {
                if (index < 0 || index >= _routes.Count) 
                    throw new IndexOutOfRangeException("Такого номера маршруту не існує!");
                _routes[index] = value;
            }
        }

        // 5. Поліморфізм (Практичне заняття 3)
        // virtual дозволяє спадкоємцям (ExcursionTour) змінювати цей опис
        public virtual string GetDescription()
        {
            return $"Тур: '{TourName}', Ціна: {BasePrice}$";
        }
    }
}