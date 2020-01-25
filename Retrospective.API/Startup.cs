﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Retrospective.API.Data;
using Retrospective.API.Engines;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Retrospective.API
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
      services.AddMvc()
        .AddXmlSerializerFormatters()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      // Add DI Engines
      services.AddScoped<IRetrospectiveRepository, RetrospectiveRepository>();
      services.AddScoped<IRetrospectiveEngine, RetrospectiveEngine>();

      services.AddCors();
      services.AddAutoMapper();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      app.UseHttpsRedirection();
      app.UseMiddleware(typeof(ErrorHandlingMiddleware));
      app.UseMvc();
    }
  }
}
