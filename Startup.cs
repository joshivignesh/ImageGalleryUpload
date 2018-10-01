using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MVCProject.Models;
using MVCProject.Services;

namespace MVCProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IImageService, ImageService>();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddDbContext<ImageContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            ////setting up constraint
            //app.UseMvc(options =>
            //{
            //    options.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id}",
            //        constraints: new { id: new IntRouteConstraint() }
            //        );
            //});


            //setting up constraint for more constraint to a particular property
            //app.UseMvc(options =>
            //{
            //    options.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id}",
            //        constraints: new { id: new CompositeRouteConstraint (new IRouteConstraint[new IntRouteConstraint(),new MinRouteConstraint()] }
                    
            //        );
            //});

        }
    }
}
