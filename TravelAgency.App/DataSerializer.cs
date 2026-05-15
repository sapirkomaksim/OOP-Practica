using System.IO;
using System.Text.Json;

namespace TravelAgency.App
{
    public static class DataSerializer
    {
        // Налаштування, щоб JSON виглядав красиво (з відступами)
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions 
        { 
            WriteIndented = true 
        };

        // Метод для збереження у файл
        public static void SaveToFile<T>(T data, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, jsonString);
        }

        // Метод для завантаження з файлу
        public static T LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default;
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}