using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroductionToNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntroductionToNetCore
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EmployeeDBContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EmployeeDBContext>()
                .AddDefaultTokenProviders();

            // Default password options override
            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequiredLength = 7;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddMvc(options =>
            {
                // Applying authorization to all controllers. [Global authorization]
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            // External Identity Provider
            services.AddAuthentication()
                .AddGoogle(options => 
                {
                    options.ClientId = "863547247076-741fn0emhkk1ji5l1f5evsfv8rsen91o.apps.googleusercontent.com";
                    options.ClientSecret = "uqV0OCMmBhsPM8J08toE-1wo";
                })
                .AddFacebook(options =>
                {
                    options.ClientId = "225745201880028";
                    options.ClientSecret = "aa313bbe7b5497d17d26191ed0ce3289";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role"));

                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin"));
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            
            //app.UseMvcWithDefaultRoute();

            // using custom routing
            //app.UseMvc(route =>
            //{
            //    route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvc(route =>
            {
                // url http://localhost:8760/pragim/ starts with pragim.
                route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // Attribute routing
            //app.UseMvc();


        }
    }
}
