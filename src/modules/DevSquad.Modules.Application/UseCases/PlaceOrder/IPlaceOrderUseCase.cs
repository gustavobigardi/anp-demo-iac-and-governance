using DevSquad.Modules.Application.Inputs;

namespace DevSquad.Modules.Application.UseCases.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
        string Execute(PlaceOrderInput orderInput);
    }
}
