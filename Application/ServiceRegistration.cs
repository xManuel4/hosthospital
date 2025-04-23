using Internetbanking.Core.Application.Interfaces.Services;
using Internetbanking.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Internetbaking.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IUserService, UserService>();
           
        }
    }
}
