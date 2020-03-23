using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetcoreProject.Core.Repositories;
using DotnetcoreProject.Core.Service;
using DotnetcoreProject.Core.UnirOfWorks;
using DotnetcoreProject.Data;
using DotnetcoreProject.Data.Repositories;
using DotnetcoreProject.Data.UnitOfWorks;
using DotnetcoreProject.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DotnetcoreProject.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using DotnetcoreProject.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DotnetcoreProject.API.Extensions;

namespace DotnetcoreProject.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers( o => {
                o.Filters.Add(new ValidationFilter());
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("DotnetcoreProject.Data");
                });
            });
            //bir requestte birden fazla ihtiya� olursa ayn� nesne �rne�ini kullna�yor olacak.Performans a��s�ndan iyi.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

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
