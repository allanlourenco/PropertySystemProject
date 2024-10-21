using Microsoft.Extensions.DependencyInjection;
using PropertySystemProject.Domain.Interfaces.Service;
using PropertySystemProject.Service.Services;

namespace PropertySystemProject.CrossCuting.IoC
{
    public class ConfigureServices
    {
        public static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
