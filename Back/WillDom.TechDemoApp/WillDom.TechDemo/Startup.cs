using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WillDom.TechDemo.Data;
using WillDom.TechDemo.Interfaces;
using WillDom.TechDemo.Mdels;

namespace WillDom.TechDemo
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
            // For this time and since I am testing it from my dev server I can do this.
            // NOT FOR production.
            services.AddCors(options =>
                    options.AddPolicy(name : "WillDomPolicy", 
                    policy => {
                        policy.WithOrigins("http://localhost:8080");
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    }));
            services.AddControllers();

            services.AddSingleton(new DbConfiguration { Name = Configuration["DatabaseName"] });
            services.AddSingleton<IDatabaseSetup, DatabaseSetup>();
            services.AddTransient<IDataService, DataService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WillDom.TechDemo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WillDom.TechDemo v1"));
            }

            app.UseCors("WillDomPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseSetup>().Setup();
        }
    }
}
