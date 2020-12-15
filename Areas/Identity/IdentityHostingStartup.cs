using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabaseProject.Data;

[assembly: HostingStartup(typeof(MovieDatabaseProject.Areas.Identity.IdentityHostingStartup))]
namespace MovieDatabaseProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MovieDatabaseProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MovieDatabaseProjectContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MovieDatabaseProjectContext>();
            });
        }
    }
}