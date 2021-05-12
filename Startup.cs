using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCAssignmentPerson.Database;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using MVCAssignmentPerson.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection to Database
            services.AddDbContext<PeopleDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));//Nr 5


            //Services IoC
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            // Lägg till Service 

            //------Repo Ioc--------
           
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();//Nr 5 Ulf använder denna. 
            services.AddScoped<ICityRepo, DbCityRepo>();
            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ILanguageRepo, DbLanguageRepo>();
            services.AddScoped<IPersonLanguageRepo, PersonLanguageRepo>();
           
            

            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
