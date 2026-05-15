using System;

namespace TravelAgency.Domain
{
    public class Client
    {
        public Guid Id { get; private set; } 

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Гей! Ім'я не може бути порожнім!");
                }
                _firstName = value; 
            }
        }

        public string LastName { get; set; }
        public string Email { get; set; }

        public Client(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid(); 
            FirstName = firstName; 
            LastName = lastName;
            Email = email;
        }
    }
}