using System;
using System.Collections.Generic;
using TravelAgency.Domain;
using TravelAgency.App;

namespace TravelAgency.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ПРАКТИКА 12: Серіалізація в JSON ===\n");

            // 1. Створюємо дані для збереження
            var tours = new List<Tour>
            {
                new TourBuilder("Тур до Риму").SetPrice(500).Build(),
                new TourBuilder("Тур до Токіо").SetPrice(2500).Build()
            };

            string fileName = "tours_backup.json";

            // 2. Зберігаємо
            Console.WriteLine("Зберігаємо тури у файл...");
            DataSerializer.SaveToFile(tours, fileName);
            Console.WriteLine($"Файл '{fileName}' створено успішно!");

            // 3. Завантажуємо назад для перевірки
            Console.WriteLine("Завантажуємо дані назад із файлу...");
            var loadedTours = DataSerializer.LoadFromFile<List<Tour>>(fileName);

            foreach (var t in loadedTours)
            {
                Console.WriteLine($"Завантажено тур: {t.TourName} за {t.BasePrice}$");
            }
        }
    }
}