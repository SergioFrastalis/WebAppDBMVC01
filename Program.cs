using Microsoft.EntityFrameworkCore;
using Serilog;
using WebAppDBMVC01.Configuration;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.Repositories;
using WebAppDBMVC01.Services;

namespace WebAppDBMVC01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");

            //AddDbContext is scoped - per request a new instance is created
            builder.Services.AddDbContext<Mvc01DbContext>(options => options.UseSqlServer(connString));
            builder.Services.AddRepositories();
            builder.Host.UseSerilog((context, config) =>
            {
                config
                    .ReadFrom.Configuration(context.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console();
            });
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<IApplicationService, ApplicationService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication("CookieAuthenticationDerfaults.AuthenticationScheme")
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
