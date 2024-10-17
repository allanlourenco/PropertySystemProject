using Microsoft.Extensions.DependencyInjection;
using PropertySystemProject.Data.Implementation;
using PropertySystemProject.Data.Repository;
using PropertySystemProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.CrossCuting.IoC
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //serviceCollection.AddScoped<IDashboardRepository, DashboardRepository>();
          
        }
    }
}
