using NUnit.Framework;
using TravelAgency.Domain;
using System;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class TourTests
    {
        [Test]
        public void Distance_ShouldThrowException_WhenValueIsNegative()
        {
            // Arrange
            var route = new Route("Київ", "Львів", 540);

            // Act & Assert (Використовуємо сучасний синтаксис NUnit 4)
            Assert.Throws<ArgumentException>(() => {
                route.Distance = -100;
            });
        }

        [Test]
        public void GetFinalPrice_ShouldApplyHotDiscount_Correctly()
        {
            // Arrange
            var tour = new Tour("Тест") { BasePrice = 1000 };
            var booking = new Booking(tour, new HotTourPricing());

            // Act
            var price = booking.GetFinalPrice();

            // Assert
            // Замість AreEqual використовуємо сучасний Assert.That
            Assert.That(price, Is.EqualTo(800));
        }
    }
}