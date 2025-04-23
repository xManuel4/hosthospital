using hosthospital.Core.Application.Interfaces.Services;
using hosthospital.Core.Application.Services;
using hosthospital.Core.Application.Interfaces.Services;
using hosthospital.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace hosthospital.Core.Application
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
