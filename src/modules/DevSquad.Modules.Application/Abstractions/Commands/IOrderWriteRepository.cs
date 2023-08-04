using DevSquad.Modules.Domain.Enums;

namespace DevSquad.Modules.Application.Abstractions.Commands
{
    public interface IOrderWriteRepository
    {
        string PlaceOrder(Customer customer, Order order);
    }
}
