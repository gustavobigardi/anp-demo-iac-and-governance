using DevSquad.Modules.Application.UseCases.PlaceOrder;
using Microsoft.Extensions.DependencyInjection;

namespace DevSquad.Modules.Infrastructure.IoC
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();
        }
    }
}
