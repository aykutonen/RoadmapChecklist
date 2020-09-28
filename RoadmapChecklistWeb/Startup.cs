using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Categories.CategoriesService;
using Service.Categories.RoadmapsCategory;
using Service.Roadmaps.CopiedRoadmaps;
using Service.Roadmaps.IRoadmapItems;
using Service.Roadmaps.Roadmaps;
using Service.RoadmapTags;
using Service.Tags;
using Service.Users;

namespace RoadmapChecklistWeb
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
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config =>
             {
                 config.Cookie.Name = "UserLoginCookie";
                 config.LoginPath = "/User/Login";

             });
            services.AddControllersWithViews();
            services.AddDbContext<RoadmapContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoadmapService, RoadmapService>();
            services.AddScoped<ICopiedRoadmapService, CopiedRoadmapService>();
            services.AddScoped<IRoadmapItemService, RoadmapItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRoadmapCategoryService, RoadmapCategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IRoadmapTagService, RoadmapTagService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
