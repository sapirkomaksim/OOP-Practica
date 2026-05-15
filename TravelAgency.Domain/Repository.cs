using System;
using System.Collections.Generic;

namespace TravelAgency.Domain
{
    // <T> — це наша Універсальна Коробка (Generic).
    // where T : class — це обмеження: "Сюди можна класти тільки складні об'єкти (як Клієнт чи Тур), а не просто цифри".
    public class Repository<T> where T : class
    {
        // Ховаємо наш список всередині
        private List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("Елемент не може бути порожнім!");
            _items.Add(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        // ==========================================
        // САМОСТІЙНА РОБОТА 5: Делегати (Action та Func)
        // ==========================================

        // 1. Універсальний ForEach (перебрати всі елементи і щось із ними зробити).
        // Action<T> — це ніби передати сюди функцію: "Ось тобі правило, застосуй його до кожного".
        public void ExecuteForAll(Action<T> action)
        {
            foreach (var item in _items)
            {
                action(item); // Виконуємо передану дію
            }
        }

        // 2. Універсальний пошук (Find).
        // Func<T, bool> — це питання до кожного елемента: "Ти нам підходиш? (Так/Ні)".
        public T FindOne(Func<T, bool> condition)
        {
            foreach (var item in _items)
            {
                if (condition(item)) 
                {
                    return item; // Знайшли! Повертаємо перший-ліпший, який підійшов
                }
            }
            return null; // Нічого не знайшли
        }
    }
}