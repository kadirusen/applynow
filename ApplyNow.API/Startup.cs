using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.API.Filters;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.Services;
using ApplyNow.Core.UnitOfWorks;
using ApplyNow.Data;
using ApplyNow.Data.Repositories;
using ApplyNow.Data.UnitOfWorks;
using ApplyNow.Service;
using ApplyNow.Service.Services;
using AutoMapper;
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

namespace ApplyNow.API
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IApplyService, ApplyService>();
            services.AddScoped<IUnitOfWorks, UnitOfWork>();

            services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o =>
                {
                    o.MigrationsAssembly("ApplyNow.Data");
                });
            });

            services.AddControllers(o => {
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //Redis
            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = Configuration.GetConnectionString("redis");
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApplyNow API", Version = "v1" });
            });


            services.AddLogging();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplyNow API");
            });

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
