using Microsoft.Extensions.DependencyInjection;
using netflix.Repository.Abstract;
using netflix.Repository.Concrete;
using netflix.Service.Abstract;
using netflix.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomeServices(this IServiceCollection services)
        {
            //services.AddScoped<IAuthorizationHandler, RequestHandler>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
