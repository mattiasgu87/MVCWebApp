using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCWebApp.Models.Home;
using MVCWebApp.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IProjectRepository, MockProjectRepository>(); //add repository
            services.AddSingleton<IPersonRepository, MockPersonRepository>(); //add repository
            services.AddHttpContextAccessor();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                //Doctor route-> can be used with temperature directly: Doctor/37,9
                endpoints.MapControllerRoute(
                    name: "Doctor",
                    pattern: "Doctor/{temperature:maxlength(15)}",
                    defaults: new { controller = "Doctor", action = "CheckFever" });

                //GuessingGame route
                endpoints.MapControllerRoute(
                    name: "GuessingGame",
                    pattern: "GuessingGame",
                    defaults: new { controller = "GuessingGame", action = "SetSession" });

                //Person route
                endpoints.MapControllerRoute(
                    name: "Personlist",
                    pattern: "Personlist",
                    defaults: new { controller = "Person", action = "Index" });
            });

        }
    }
}
