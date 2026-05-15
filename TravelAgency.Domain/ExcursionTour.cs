namespace TravelAgency.Domain
{
    // Двокрапка означає "Екскурсійний тур НАСЛІДУЄ все від звичайного Tour"
    public class ExcursionTour : Tour
    {
        public int NumberOfExcursions { get; set; }

        // base(tourName) передає ім'я туру в конструктор батька
        public ExcursionTour(string tourName, decimal basePrice, int numberOfExcursions) 
            : base(tourName) 
        {
            BasePrice = basePrice;
            NumberOfExcursions = numberOfExcursions;
        }

        // ПРАВИЛЬНА ЗМІНА (override - поліморфізм)
        public override string GetDescription()
        {
            // base.GetDescription() бере текст батька, і ми доклеюємо своє!
            return base.GetDescription() + $", Включено екскурсій: {NumberOfExcursions}";
        }
    }
}