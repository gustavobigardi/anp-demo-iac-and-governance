namespace DevSquad.Modules.Application.Inputs
{
    public sealed class PlaceOrderInput
    {
        public Guid CustomerId { get; set; }
        public required PlaceOrderProductInput ProductItem { get; set; }
    }
}
