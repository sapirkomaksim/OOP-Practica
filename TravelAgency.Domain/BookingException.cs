using System;

namespace TravelAgency.Domain
{
    // Наша власна помилка наслідує стандартний Exception
    public class BookingException : Exception
    {
        // Додаємо властивість, щоб знати, коли саме сталася помилка
        public DateTime ErrorDate { get; private set; }

        public BookingException(string message) : base(message)
        {
            ErrorDate = DateTime.Now;
        }
    }
}