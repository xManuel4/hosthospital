using hosthospital.Infrastructure.Identity.Context;
using hosthospital.Infrastructure.Identity.Entities;
using hosthospital.Infrastructure.Identity.Seeds;
using hosthospital.Infrastructure.Identity.Services;
using hosthospital.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;
using static System.Formats.Asn1.AsnWriter;


namespace hosthospital.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration config)
        {

            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("applicationDB"));

            }
            else
            {
                var conn = config.GetConnectionString("IdentityConnection");
                services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(conn, m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }


            #region Identity

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();
            #endregion


            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion

        }

        public static async Task IdentitySeed(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


                    await DefaultRoles.SeedAsync(roleManager);
                    await DefaultSuperAdminUser.SeedAsync(userManager);
                    await DefaultBasicUser.SeedAsync(userManager);


                }
                catch (Exception ex)
                {

                }
            }
        }  
    }
}
