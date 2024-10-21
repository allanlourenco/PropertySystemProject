using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PropertySystemProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.CrossCuting.IoC
{
    public class ConfigureDataBase
    {
        public static void AddDatabase(IServiceCollection services)
        {
            services.AddDbContext<PropertyWebContext>(options =>
                options.UseInMemoryDatabase("MinhaBaseInMemory"));
            //var connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //services.AddDbContext<PropertyWebContext>(options =>
            //    options.UseSqlServer(connectionString));
        }
    }
}
