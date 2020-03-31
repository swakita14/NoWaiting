using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NowaiterApi.DAL;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Services;
using RestSharp;

namespace NowaiterApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Using Autofac for the IoC instead of the pre-included one 
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add Framework service
            services.AddMvc();
            services.AddDbContext<NowaiterContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:NowaiterDB"]));
            services.AddControllers();

            // Register Autofac Container
            var builder = new ContainerBuilder();

            // API key for Google Places 
            var key = "";

            // Register RestClient for Google Places 
            builder.Register(x =>
                new RestClient($"https://maps.googleapis.com/maps/api/place")).Keyed<IRestClient>("GooglePlaces");

            // Registering Google Places client with api key 
            builder.Register(x => new PlacesClient(x.ResolveKeyed<IRestClient>("GooglePlaces"), key))
                .As<IPlacesClient>();

            // Register Services

            // Register repositories


            builder.Populate(services);
            var container = builder.Build();

            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
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
                endpoints.MapControllers();
            });
        }
    }
}
