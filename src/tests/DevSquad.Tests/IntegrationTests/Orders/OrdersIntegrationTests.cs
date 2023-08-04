using DevSquad.Modules.Application.Inputs;
using DevSquad.Modules.Application.UseCases.PlaceOrder;
using DevSquad.Tests.Fakes;
using Flunt.Notifications;

namespace DevSquad.Tests.IntegrationTests.Orders
{
    public class OrdersIntegrationTests : Notifiable
    {
        [Test]
        public void OrderTests_PlaceOrder_ReturnOrderNumber()
        {
            PlaceOrderUseCase _placeOrder = new(
                new FakeOrderWriteRepository()
                );

            Guid customerId = Guid.NewGuid();

            var input = new PlaceOrderInput()
            {
                CustomerId = customerId,
                ProductItem = new PlaceOrderProductInput()
                {
                    Description = "O melhor teclado da Microsoft",
                    Image = "teclado.png",
                    Price = 10M,
                    Title = "Teclado Microsoft",
                    Quantity = 5
                }
            };

            string order = _placeOrder.Execute(input);

            AddNotifications(_placeOrder.Notifications);

            Assert.That(!Invalid, Is.EqualTo(true));
        }
    }
}