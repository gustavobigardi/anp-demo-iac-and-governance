using DevSquad.Adapters.SqlServer;
using DevSquad.Modules.Application.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DevSquad.Modules.Infrastructure.IoC
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        }
    }
}
