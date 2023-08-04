using DevSquad.Modules.Domain.Enums;
using DevSquad.Modules.Domain.ValueObjects;
using Flunt.Notifications;
using Valhalla.Modules.Domain.Enums;

namespace DevSquad.Tests.Entities
{
    public class OrderTests : Notifiable
    {

        private Product _teclado;
        private Product _mouse;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("contato@academiadotnet.com.br");

            _teclado = new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10);
            _mouse = new Product("Mouse Microsoft", "Melhor mouse", "mouse.jpg", 5M, 10);
            _monitor = new Product("Dell", "Melhor monitor", "dell.jpg", 50M, 10);

            _customer = new Customer(name, cpf, email, "11-5555-5555");
            _order = new Order(_customer);
        }


        [Test]
        public void OrderTests_CreateOrder_WhenValidReturnTrue()
        {
            Assert.That(_order.Valid, Is.EqualTo(true));
        }

        [Test]
        public void OrderTests_CreateOrder_WhenCreatedStatusIsCreated()
        {
            Assert.That(_order.Status, Is.EqualTo(EOrderStatus.Created));
        }

        [Test]
        public void OrderTests_CreateOrder_OrderItemMustBe2()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_teclado, 5);
            _order.AddItem(_teclado, 5);

            Assert.That(_order.Itens.Count, Is.EqualTo(3));
        }

        [Test]
        public void OrderTests_AddItem_ShouldSubtract5FromStock()
        {
            _order.AddItem(_monitor, 5);

            Assert.That(_monitor.StockQuantity, Is.EqualTo(5));
        }

        [Test]
        public void OrderTests_CreateOrder_ShouldHave2ShippingsIfHigherThan5()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.That(_order.Deliveries.Count, Is.EqualTo(2));
        }
    }
}
