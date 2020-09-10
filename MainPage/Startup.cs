using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DataAcces;
using Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace MainPage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);

            services.AddDbContext<MysqlDbContext>(o => o.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services = SetupModels(services);
            services = SetupServices(services);
            services = SetupWebAPI(services);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private IServiceCollection SetupModels(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(Model)).GetTypes().Where(x => !x.IsNested).ToList();
            foreach(var type in list)
            {
                if (type.Name == "BaseModel" || type.Name == "MS_Message")
                    continue;

                services.AddTransient(type);
            }
            return services;
        }
        private IServiceCollection SetupServices(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(Service)).GetTypes().Where(x => !x.IsNested && !x.Name.StartsWith("I")).ToList();
            foreach(var type in list)
            {
                if(type.Name == "UserService")
                {
                    services.AddScoped(type.GetInterfaces().First(), type);
                    continue;
                }
                services.AddTransient(type.GetInterfaces().First(), type);
            }
            return services;

        }
        private IServiceCollection SetupWebAPI(IServiceCollection services)
        {
            var list = Assembly.Load(nameof(MainPage)).GetTypes().Where(x => !x.IsNested && x.Name.Contains("Controller")).ToList();
            foreach (var type in list)
            {
                services.AddTransient(type);
            }
            return services;

        }
    }
}
