using CellShop_Api.AutoMapperConfig;
using CellShop_Api.Data;
using CellShop_Api.Interface;
using CellShop_Api.Interface.IServices;
using CellShop_Api.Models;
using CellShop_Api.Services;
using CellShop_Api.Unit_Of_Work;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellShop_Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CellShop_Api", Version = "v1" });
            });

            services.AddDbContext<CellShopDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("CellshopDbSql"))
                );

            //config automapper
            var mappingconfig = new AutoMapper.MapperConfiguration(
                m => m.AddProfile(
                    new AutoMapperProfile()
                    ));

            AutoMapper.IMapper mapper = mappingconfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericService<Categorie>, CategorieService>();
            services.AddScoped<IGenericService<Brand>, BrandService>();
            services.AddScoped<IGenericService<ModelProduct>, ModelProductService>();
            services.AddScoped<IGenericService<Product>, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CellShop_Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
