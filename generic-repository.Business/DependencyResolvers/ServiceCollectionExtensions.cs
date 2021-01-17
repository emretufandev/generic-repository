using generic_repository.Business.Abstract;
using generic_repository.Business.Services;
using generic_repository.Data;
using generic_repository.Data.Abstract;
using generic_repository.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionStrings:Sql"].ToString(),
                    o => o.MigrationsAssembly("generic-repository.Data")
                    );
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
