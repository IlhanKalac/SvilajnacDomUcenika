﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DomUcenikaSvilajnac.DAL.Context;
using AutoMapper;
using DomUcenikaSvilajnac.Common.Interfaces;
using DomUcenikaSvilajnac.DAL.RepoPattern;

namespace DomUcenikaSvilajnac
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
            services.AddCors();

            //liniju koju smo dodali kako bismo ispisali listu postanskih brojeva u opstini kontroleru
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });

            services.AddAutoMapper();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<UcenikContext>(options=>options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DomUcenikaSvilajnac;Integrated Security=True;Connect Timeout=30"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost"));
            app.UseMvc();
        }
    }
}
