using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.BAL;
using TvProgram.BAL.Interfaces;
using TvProgram.DAL;
using TvProgram.DAL.Repository;
using TvProgram.DAL.Repository.Interfaces;

namespace TvProgram
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
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews().AddFluentValidation(mvcConf => mvcConf.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<DataDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TvProgramConnection")));
            services.AddTransient<ITvPostajeService, TvPostajeService>();
            services.AddTransient<IEmisijeService, EmisijeService>();
            services.AddTransient<IZanroviService, ZanroviService>();
            services.AddTransient<ITvPostajeRepository, TvPostajeRepository>();
            services.AddTransient<IEmisijeRepository, EmisijeRepository>();
            services.AddTransient<IZanroviRepository, ZanroviRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=tvpostaje}/{action=lista}");
            });
        }
    }
}
