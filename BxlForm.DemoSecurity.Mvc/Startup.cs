using BxlForm.DemoSecurity.Mvc.Models.Client.Repositories;
using BxlForm.DemoSecurity.Mvc.Models.Client.Services;
using GR = BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using GS = BxlForm.DemoSecurity.Mvc.Models.Global.Services;
using Tools.Connections.Database;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BxlForm.DemoSecurity.Mvc.Infrastructure.Session;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BxlForm.DemoSecurity.Mvc
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddTransient(sp =>
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:7001/") };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ISessionManager sessionManager = sp.GetService<ISessionManager>();
                if (sessionManager.User is not null)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionManager.User.Token);

                return client;
            });
            services.AddScoped<GR.IAuthRepository, GS.AuthService>();
            services.AddScoped<GR.IContactRepository, GS.ContactService>();
            services.AddScoped<GR.ICategoryRepository, GS.CategoryService>();
            services.AddScoped<IContactRepository, ContactService>();
            services.AddScoped<ICategoryRepository, CategoryService>();
            services.AddScoped<IAuthRepository, AuthService>();
            services.AddScoped<ISessionManager, SessionManager>();
            
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
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}
