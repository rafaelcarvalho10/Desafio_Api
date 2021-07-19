using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Api.Data.Context;
using Desafio.Api.Host.DependencyGroups;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Desafio.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
      services.RegisterDependencyGroupFromAssemblies();
      services.AddControllers();

      services.AddCors();

      // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      // services.AddScoped<AuthenticatedUser>();

      // var keyJwt = Environment.GetEnvironmentVariable("JWT_SECRET");

      // services.AddAuthentication(x =>
      // {
      //   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      // }).AddJwtBearer(x =>
      // {
      //   x.RequireHttpsMetadata = true;
      //   x.SaveToken = true;
      //   x.TokenValidationParameters = new TokenValidationParameters
      //   {
      //     ValidateIssuer = false,
      //     ValidateIssuerSigningKey = true,
      //     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"))),
      //     ValidateAudience = false
      //   };
      // });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "deafio.api", Version = "v1" });
      });

      var SQL_CONNECTION = Environment.GetEnvironmentVariable("SQL_CONNECTION");

      services.AddDbContext<RepositoryDbContext>(options =>
      {
        options
                 .UseSqlServer(SQL_CONNECTION, providerOptions => providerOptions
                 .EnableRetryOnFailure(3)
                 .CommandTimeout(30)
             )
          .UseLazyLoadingProxies(false);

      });
      services.AddScoped<RepositoryDbContext, RepositoryDbContext>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseSwagger();
      // app.UseSwaggerUI(c =>
      //     {
      //       c.SwaggerEndpoint("/swagger/v1/swagger.json", "desafio.api v1");
      //       c.RoutePrefix = string.Empty;
      //       c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
      //     }
      // );

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      UpdateDatabase(app);
    }

    private static void UpdateDatabase(IApplicationBuilder app)
    {

      using (var serviceScope = app.ApplicationServices
          .GetRequiredService<IServiceScopeFactory>()
          .CreateScope())
      {
        using (var context = serviceScope.ServiceProvider.GetService<RepositoryDbContext>())
        {
          context.RunMigrate();
        }
      }
    }
  }
}
