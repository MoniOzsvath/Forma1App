using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Forma1App.Data;
using Forma1App.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Forma1App.Repositories;
using AutoMapper;
using Forma1App.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Forma1App.Exceptions;
using Microsoft.AspNetCore.Http;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using Forma1App.Data.Utils;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace Forma1App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            inMemorySqlite.Open();
            
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlite(inMemorySqlite);
            });

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //    services.AddControllers();
            services.AddScoped<IForma1TeamRepository, Forma1TeamRepository>();
            services.AddAutoMapper(typeof(Forma1TeamController).Assembly);

            services.AddTransient<IdentityInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ApplicationDbContext context,
            IdentityInitializer identityInitializer)
        {
            context.Database.EnsureCreated();

            app.UseExceptionHandler(errorApp =>
            errorApp.Run(async context =>
            {
                context.Response.ContentType = "text/Plain";
                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionHandlerPathFeature?.Error is EntityAlreadyExistsException)
                {
                    context.Response.StatusCode = 409;
                    await context.Response.WriteAsync("Enity already exsist!");
                }
                else if (exceptionHandlerPathFeature?.Error is EntityNotFoundException)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("Enity not found!");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Oops, something bad happened!");
                }
            }));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            identityInitializer.SeedAdminUser();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
