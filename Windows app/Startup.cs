using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Windows_app.DataAccess;
using Windows_app.ViewModels;
namespace Windows_app
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
             
            services.AddScoped<IEmployeeContext, SQLEmployeeRepository>();
             
            services.AddDbContextPool<ApplicationContext>
                (option=>option.UseSqlServer(_configuration.GetConnectionString("EmployeeDB")) ,
                poolSize:10);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                DeveloperExceptionPageOptions options = new DeveloperExceptionPageOptions();
                options.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(options);
            }
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");

            //  app.UseRouting();

            //app.UseDefaultFiles(defaultFilesOptions);
            //MvcOptions mvcOptions = new MvcOptions();
            //mvcOptions.EnableEndpointRouting = false;
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.Use(async (context, next) =>
            //            {
            //                await context.Response.WriteAsync("Middleware1 begins");
            //                await next.Invoke();
            //                await context.Response.WriteAsync("Middleware1 ends");
            //            }
            //);
            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync("Middleware2 begins");

            //    await context.Response.WriteAsync("Middleware2 ends");
            //}
            //);

        }
    }
}
