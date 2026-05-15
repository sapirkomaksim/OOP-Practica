using System;

namespace TravelAgency.Domain
{
    // Слово abstract означає: "Не можна створити просто Знижку, 
    // можна створити лише її конкретних спадкоємців"
    public abstract class Discount
    {
        public string Name { get; set; } // Спільна властивість для всіх знижок

        public Discount(string name)
        {
            Name = name;
        }

        // Абстрактний метод: "Я не знаю ЯК це рахувати, хай спадкоємці самі вирішують"
        public abstract decimal CalculateDiscount(decimal basePrice);
    }

    // --- А тепер створюємо конкретних спадкоємців ---

    // 1. Відсоткова знижка (наприклад, 10%)
    public class PercentageDiscount : Discount
    {
        public decimal Percentage { get; set; }

        public PercentageDiscount(string name, decimal percentage) : base(name)
        {
            Percentage = percentage;
        }

        // Реалізуємо обіцянку батька (обов'язково слово override)
        public override decimal CalculateDiscount(decimal basePrice)
        {
            return basePrice - (basePrice * (Percentage / 100));
        }
    }

    // 2. Фіксована знижка (наприклад, мінус 50 доларів)
    public class FixedDiscount : Discount
    {
        public decimal Amount { get; set; }

        public FixedDiscount(string name, decimal amount) : base(name)
        {
            Amount = amount;
        }

        public override decimal CalculateDiscount(decimal basePrice)
        {
            return basePrice - Amount;
        }
    }
}