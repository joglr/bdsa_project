using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using api.Entities;
using api.Models;

namespace api.Api
{
  public class Startup
  {
    readonly string AllowedDevelopmentOrigins = "_allowedDevelopmentOrigins";
    readonly string AllowedProductionOrigins = "_allowedProductionOrigins";


    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(name: AllowedDevelopmentOrigins,
                          builder =>
                          {
                            builder.WithOrigins(
                              "http://localhost:3000"
                            ).AllowAnyMethod().AllowAnyHeader();
                          });
      });

      services.AddCors(options =>
      {
        options.AddPolicy(name: AllowedProductionOrigins,
                          builder =>
                          {
                            builder.WithOrigins(
                              "https://pladat.joglr.dev"
                            ).AllowAnyMethod().AllowAnyHeader();
                          });
      });

      services.AddDbContext<PlaDatContext>(o => o.UseSqlite("Data Source=pladat.db"));
      // TODO: services.AddDbContext<PlaDatContext>(o => o.UseSqlServer(<connectionString from user secrets>));

      services.AddScoped<IPlaDatContext, PlaDatContext>();

      services.AddScoped<IEmployerRepository, EmployerRepository>();
      services.AddScoped<IPlacementRepository, PlacementRepository>();
      services.AddScoped<IStudentRepository, StudentRepository>();
      services.AddScoped<ICapabilityRepository, CapabilityRepository>();

      services.AddControllers();
      services.AddRouting(options => options.LowercaseUrls = true);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.Api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<PlaDatContext>();

        // Only regenerate data if the database is fresh
        if (context.Database.EnsureCreated())
        {
          context.GenerateData();
        }
      }

      if (env.IsDevelopment())
      {
        System.Console.WriteLine("Development");
        app.UseDeveloperExceptionPage();
        app.UseCors(AllowedDevelopmentOrigins);
      }
      else
      {
        app.UseCors(AllowedProductionOrigins);
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.Api v1");
        c.RoutePrefix = string.Empty;
      });
    }
  }
}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
