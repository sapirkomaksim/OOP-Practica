namespace TravelAgency.Domain
{
    public class BeachTour : Tour
    {
        public string BeachName { get; set; }

        public BeachTour(string tourName, decimal basePrice, string beachName) 
            : base(tourName)
        {
            BasePrice = basePrice;
            BeachName = beachName;
        }

        // НЕПРАВИЛЬНА ЗМІНА (new - приховування)
        // Слово new просто перекриває метод батька, замість того, щоб його оновити.
        public new string GetDescription()
        {
            return $"Пляжний тур: '{TourName}' на пляжі {BeachName}. Ціна: {BasePrice}$";
        }
    }
}