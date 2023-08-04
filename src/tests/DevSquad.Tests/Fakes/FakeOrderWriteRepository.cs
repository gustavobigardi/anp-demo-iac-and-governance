using DevSquad.Modules.Application.Abstractions.Commands;
using DevSquad.Modules.Domain.Enums;

namespace DevSquad.Tests.Fakes
{
    public class FakeOrderWriteRepository : IOrderWriteRepository
    {
        public string PlaceOrder(Customer customer, Order order)
        {
            return "0123456789";
        }
    }
}
