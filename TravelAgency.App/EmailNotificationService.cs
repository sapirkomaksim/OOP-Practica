using System;
using TravelAgency.Domain;

namespace TravelAgency.App
{
    // Двокрапка тут означає: "Я підписую контракт INotificationService"
    public class EmailNotificationService : INotificationService
    {
        public void Send(Client client, string message)
        {
            // Тут міг би бути складний код відправки листа через інтернет
            Console.WriteLine($"[EMAIL ВІДПРАВЛЕНО] Кому: {client.Email}");
            Console.WriteLine($"[ТЕКСТ]: Шановний/а {client.FirstName}, {message}");
        }
    }
}