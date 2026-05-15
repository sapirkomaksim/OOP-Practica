using TravelAgency.Domain;

namespace TravelAgency.App
{
    // Це просто контракт. Він каже: "Хто підпише мене, мусить мати метод Send"
    public interface INotificationService
    {
        void Send(Client client, string message);
    }
}