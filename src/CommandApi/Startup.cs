using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using AutoMapper;

namespace CommandApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection String Builder Using User Secrets
            var builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = Configuration.GetConnectionString("CommandApiConnection");
            builder.UserID = Configuration["UserID"];
            builder.Password = Configuration["Password"];

            services.AddDbContext<CommandContext>(opt => opt.UseSqlServer
            (builder.ConnectionString));

            services.AddControllers(); //
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddScoped<ICommandApiRepo, MockCommandApiRepo>();
            services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
