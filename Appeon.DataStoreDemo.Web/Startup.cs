using Appeon.DataStoreDemo.Service.Datacontext;
using Appeon.DataStoreDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SnapObjects.Data;
using SnapObjects.Data.AspNetCore;
using SnapObjects.Data.SqlServer;
using System.IO.Compression;
namespace Appeon.MvcModelMapperDemo
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
            services.AddRazorPages();

            services.AddDataContext<OrderContext>(m => m.UseSqlServer(Configuration["ConnectionStrings:AdventureWorks2012"]));

            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IOrderReportService, OrderReportService>();
            services.AddScoped<IGenericServiceFactory, GenericServiceFactory>();

            services.AddScoped<ISalesOrderDetailService, SalesOrderDetailService>();
            services.AddScoped<ILoginService, LoginService>();


            services.AddGzipCompression(CompressionLevel.Fastest);

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    
                });

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddSession();
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
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
