namespace TravelAgency.Domain
{
    public interface IPricingStrategy
    {
        decimal Calculate(decimal basePrice);
    }
}