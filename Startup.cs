using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud__operation.RepositoryLayer;
using crud__operation.ServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Web.Http.Cors;
//using Microsoft.AspNetCore.Cors;

namespace crud__operation
{
    public class Startup{
      
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            
           


            services.AddControllers();
            services.AddTransient<ICrudOperationSL, CrudOperationSL>();
            services.AddTransient<ICrudOperationRL, CrudOperationRL>();
            services.AddSwaggerGen();
            services.AddCors(options => options.AddDefaultPolicy(
             builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()

         ));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

        
       

            app.UseRouting();
            app.UseCors();

          
           


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });
        }
    }
}
