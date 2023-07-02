using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skillfactory_35.Models.Users;
using Skillfactory_35.Data.Repository;
using Skillfactory_35.Data.Context;
using Skillfactory_35.Data.UnitOfWork;
using Skillfactory_35.Data.Mapper;
using Skillfactory_35.Extensions;

namespace Skillfactory_35
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");

            services
   .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
   .AddCustomRepository<Friend, FriendsRepository>()
                .AddCustomRepository<Message, MessageRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            
        }

        // Метод вызывается средой ASP.NET.
        // Используйте его для настройки конвейера запросов
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!"); });
            });

            // Добавим в конвейер запросов обработчик самым простым способом
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Page not found");
            });
        }
    }
}
