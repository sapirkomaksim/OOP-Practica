using System;

namespace TravelAgency.Domain
{
    public class Route
    {
        public Guid Id { get; private set; }

        // Заховані проводки для відстані
        private double _distance;

        // Кнопка з охоронцем (Інкапсуляція)
        public double Distance
        {
            get { return _distance; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Помилка! Відстань має бути більшою за 0 км.");
                }
                _distance = value;
            }
        }

        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }

        // Конструктор
        public Route(string departureCity, string destinationCity, double distance)
        {
            Id = Guid.NewGuid();
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
            Distance = distance; 
        }

        // ==========================================
        // МАГІЯ: ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ
        // ==========================================

        // 1. Вчимо додавати маршрути через +
        public static Route operator +(Route r1, Route r2)
        {
            double totalDistance = r1.Distance + r2.Distance;
            // Новий маршрут: старт від першого, фініш від другого
            return new Route(r1.DepartureCity, r2.DestinationCity, totalDistance);
        }

        // 2. Вчимо порівнювати маршрути через ==
        public static bool operator ==(Route r1, Route r2)
        {
            // Якщо це буквально один і той самий маршрут або обидва порожні
            if (ReferenceEquals(r1, r2)) return true;
            if (r1 is null || r2 is null) return false;

            // Вони однакові, якщо збігаються міста і відстань
            return r1.DepartureCity == r2.DepartureCity && 
                   r1.DestinationCity == r2.DestinationCity && 
                   r1.Distance == r2.Distance;
        }

        // 3. Вчимо перевіряти нерівність через !=
        public static bool operator !=(Route r1, Route r2)
        {
            return !(r1 == r2); // Просто робимо навпаки від ==
        }

        // Системні налаштування (щоб комп'ютер не сварився на ==)
        public override bool Equals(object obj)
        {
            if (obj is Route otherRoute)
            {
                return this == otherRoute;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DepartureCity, DestinationCity, Distance);
        }
    }
}