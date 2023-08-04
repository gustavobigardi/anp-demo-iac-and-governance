using DevSquad.Modules.Application.Abstractions.Commands;
using DevSquad.Modules.Application.Inputs;
using DevSquad.Modules.Domain.Enums;
using DevSquad.Modules.Domain.ValueObjects;
using Flunt.Notifications;

namespace DevSquad.Modules.Application.UseCases.PlaceOrder
{
    public class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
    {

        private readonly IOrderWriteRepository _orderWriteOnlyRepository;

        private Customer? _customer;
        private Order? _order;

        public PlaceOrderUseCase(IOrderWriteRepository orderWriteOnlyRepository)
        {
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
        }

        public string Execute(PlaceOrderInput order)
        {
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("rayca@microsoft.com");
            _customer = new Customer(name, cpf, email, "11-5555-5555");

            if (_customer.Invalid)
            {
                AddNotification("Cliente", "Erros identificados nos dados de cliente: ");
                return _customer
                    .Notifications
                    .First()
                    .Message;
            }

            _order = new Order(_customer);

            var product = new Product(
                order.ProductItem.Title,
                order.ProductItem.Description,
                order.ProductItem.Image,
                order.ProductItem.Price,
                order.ProductItem.Quantity);

            _order.AddItem(
                product,
                order.ProductItem.Quantity
                );

            if (_order.Invalid)
            {
                AddNotification("Pedido", "Erros identificados nos dados do seu pedido: ");
                return _order
                    .Notifications
                    .First()
                    .Message;
            }
            string orderId;

            try
            {
                orderId = 
                    _orderWriteOnlyRepository
                    .PlaceOrder(_customer, _order);
            }
            catch
            {
                throw new Exception($"Error executing PlaceOrderUseCase: Execute()");
            }

            return "Número do pedido: " + orderId;
        }
    }
}
