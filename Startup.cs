using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AllAddOnsAPI.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization; 
using Microsoft.IdentityModel.Tokens;

namespace AllAddOnsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object Encoding { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

        //Auth
        //byte[] toEncrypt = System.Text.Encoding.Unicode.GetBytes(yawe);
        // string yawe ="hfhfhfhlhfklhflhflhsklhflkshflhsfhlkshfklhfkhslfhlshfklshflkhsklfhslkhflshfklh";
        // var key = new SymmetricSecurityKey(System.Text.Encoding.Unicode.GetBytes(yawe));

         // key
         string securityKey ="my_super_long_secutiry_key_for_token_validation_project_all_add_on";
         //symmetric key
         var symmetricKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
        

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        // what to validate
                        ValidateIssuer =  true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        // setup data
                        ValidIssuer = "renzen.net",
                        ValidAudience = "readers",
                        IssuerSigningKey = symmetricKey,
                    };
            });
            //Auth
 

            services.AddDbContext<addOnContext>(db => db.UseSqlServer(Configuration.GetConnectionString("HWPOD")));
            services
            .AddMvc()
            .AddJsonOptions(options => {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); 
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c=> c.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin()
            .AllowCredentials());
            //Auth
            app.UseAuthentication();
            //Auth
            app.UseMvc();

            // else
            // {
            //     app.UseHsts();
            // }

            // app.UseHttpsRedirection();
            // app.UseMvc();
        }
    }
}
