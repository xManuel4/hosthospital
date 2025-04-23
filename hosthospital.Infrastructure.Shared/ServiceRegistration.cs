using hosthospital.Core.Application.Interfaces.Services;
using hosthospital.Core.Domain.Settings;
using hosthospital.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosthospital.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings")); 
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
