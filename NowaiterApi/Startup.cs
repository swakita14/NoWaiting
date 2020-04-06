using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NowaiterApi.Client;
using NowaiterApi.DAL;
using NowaiterApi.DAL.Repositories;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.GoogleClient;
using RestSharp;

namespace NowaiterApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; private set; }

        //public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Using Autofac for the IoC instead of the pre-included one 
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Framework service
            services.AddMvc();
            services.AddDbContext<NowaiterContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:NowaiterDB"]));
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // API key for Google Places 
            var apiKey = "";

            // Register RestClient for Google Places 
            builder.Register(x =>
                new RestClient($"https://maps.googleapis.com/maps/api/place/")).Keyed<IRestClient>("GooglePlaces");

            // Registering Google Places client with api key 
            builder.Register(x => new PlacesClient(x.ResolveKeyed<IRestClient>("GooglePlaces"), apiKey))
                .As<IPlacesClient>();

            // Register Services

            // Register repositories
            builder.RegisterType<LocationRepository>().As<ILocationRepository>();
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<StatusRepository>().As<IStatusRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller=GooglePlaces}/{action=Index}");
                });
        }
    }
}
