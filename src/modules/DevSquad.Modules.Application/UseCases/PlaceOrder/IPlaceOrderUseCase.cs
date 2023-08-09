using DevSquad.Modules.Application.Inputs;

namespace DevSquad.Modules.Application.UseCases.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
        Task<string> Execute(PlaceOrderInput orderInput);
        Task<string> GetOrderByIdAsync(Guid id);
    }
}
