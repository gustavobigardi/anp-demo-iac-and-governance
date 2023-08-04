using DevSquad.Modules.Domain.Enums;

namespace DevSquad.Modules.Application.Abstractions.Queries
{
    public interface IGetOrdersByCustomerQuery
    {
        IEnumerable<Order> GetOrder(Guid orderId);
    }
}