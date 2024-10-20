using Microsoft.Extensions.DependencyInjection;
using PropertySystemProject.Data.Implementation;
using PropertySystemProject.Data.Repository;
using PropertySystemProject.Domain.Interfaces.Repository;

namespace PropertySystemProject.CrossCuting.IoC
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
            serviceCollection.AddScoped<IPropertyRepository, PropertyRepository>();

            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
