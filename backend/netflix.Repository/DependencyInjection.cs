using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflix.Repository.Abstract;
using netflix.Repository.Concrete;
using netflix.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUserRepository, UserRepository>();

            //services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<netflixDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var db = serviceProvider.GetRequiredService<netflixDbContext>();
                //bu kalkýnca migration hatasu düzelir
                //db.Database.EnsureCreated();

            }

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IUserInterestRepository, UserInterestRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IProgramInterestRepository, ProgramInterestRepository>();

            return services;
        }
    }
}
