using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public interface IModule
    {
        void Registry(IServiceCollection services);
    }
}
