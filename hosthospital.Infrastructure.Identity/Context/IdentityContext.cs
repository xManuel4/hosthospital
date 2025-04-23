using hosthospital.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosthospital.Infrastructure.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");


            builder.Entity<ApplicationUser>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(enity => enity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(enity => enity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserLogin<string>>(enity => enity.ToTable(name: "UserLogins"));


        }
    }
}
