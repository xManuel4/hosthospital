using Internetbanking.Core.Application.Interfaces.Services;
using Internetbanking.Core.Domain.Settings;
using Internetbanking.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internetbanking.Infrastructure.Shared
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
