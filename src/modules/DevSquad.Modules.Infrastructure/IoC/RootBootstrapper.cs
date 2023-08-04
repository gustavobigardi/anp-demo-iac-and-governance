using Microsoft.Extensions.DependencyInjection;

namespace DevSquad.Modules.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}
