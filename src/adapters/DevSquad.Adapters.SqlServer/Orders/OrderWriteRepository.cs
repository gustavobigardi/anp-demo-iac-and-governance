using DevSquad.Modules.Application.Abstractions.Commands;
using DevSquad.Modules.Domain.Enums;

namespace DevSquad.Adapters.SqlServer.Order
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        public string PlaceOrder(Customer customer, Modules.Domain.Enums.Order order)
        {
            //to-do: configure connection with SQL Server

            const string characters = "0123456789" +
                                                  "abcdefghijklmnopqrstuvwxyz" +
                                                  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var random = new Random();
            return new string(Enumerable.Repeat(characters, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
