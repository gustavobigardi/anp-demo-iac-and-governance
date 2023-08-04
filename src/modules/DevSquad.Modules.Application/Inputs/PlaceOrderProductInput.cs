namespace DevSquad.Modules.Application.Inputs
{
    public class PlaceOrderProductInput
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
