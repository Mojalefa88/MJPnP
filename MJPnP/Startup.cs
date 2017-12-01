using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MJPnP.DAL;
using MJPnP.Models;
using Microsoft.EntityFrameworkCore;

namespace MJPnP
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
            services.AddMvc();
            services.AddDbContext<PnPDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
          
            services.AddTransient<IRepository<int, Customer>, CustomerRepository>();
            services.AddTransient<IProductRepository<int, Product>, ProductRepository>();
            services.AddTransient<IProductCategoryRepository<int, ProductCategoryViewModel>, ProductRepository>();
            services.AddTransient<ITrolleyRepository<int, Cart>, TrolleyService>();
            services.AddTransient<ICartProductRepository<int, CartProductViewModel>, TrolleyService>();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSession();
        }
    }
}
