using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public static class DataAccessServices
    {
        public static IConfigurationManager _configuration;
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            _configuration = configuration;
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppDbConnection"));
            });

            return services;
        }
    }
}
