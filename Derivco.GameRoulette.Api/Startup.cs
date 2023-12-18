using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Derivco.GameRoulette.Identity.DbContext;
using Derivco.GameRoulette.Application.Contracts.Identity;
using Derivco.GameRoulette.Identity.Services;
using Derivco.GameRoulette.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Derivco.GameRoulette.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Derivco API", Version = "v1" });
            });
            services.AddDbContext<DerivcoIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DerivcoDatabaseConnectionString")));
            //services.AddScoped<IAuthService, AuthService>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DerivcoIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddDbContext<DerivcoIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DerivcoDatabaseConnectionString")), ServiceLifetime.Scoped);
            services.AddScoped<IAuthService, AuthService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Derivco API V1");
            });
        }
    }
}
