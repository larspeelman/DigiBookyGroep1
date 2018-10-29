
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Books;
using Digibooky_domain.Users;
using Digibooky_services.Books;
using Digibooky_services.Rentals;
using Digibooky_services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;

namespace Digibooky_api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IRentalService, RentalService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>()
                    .AddSingleton<IBookRepository, BookRepository>()
                    .AddSingleton<IBookMapper, BookMapper>()
                    .AddSingleton<IMapperUser, MapperUser>()
                    .AddSingleton<IRentalService, RentalService>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ModeratorAccess",
                    policy => policy.RequireRole(Roles.Role.Libarian.ToString()
                                               , Roles.Role.Administrator.ToString()));

            });
            services.AddSwagger();
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
                app.UseHsts();
            }
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
