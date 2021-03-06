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
using MovingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MovingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Arbitary cors policy name
        readonly string localhostCors = "_localhostCors";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            //services.AddMvc(option => option.EnableEndpointRouting = false)
                //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                //.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<MovingContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MovingContext")));

            //Creates a cors policy to allow specific domains to requests resources from this api server.
            services.AddCors(options =>
            {
                options.AddPolicy(localhostCors,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000");
                });
            });
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

            //Uses the previously built localhost cors policy to allow the localhost:3000 domain to request resources.
            app.UseCors(localhostCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
