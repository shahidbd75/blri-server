using AutoMapper;
using BLRI.API.Provider;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Repositories.Core;
using BLRI.Manager.Interfaces.Core;
using BLRI.Manager.Map;
using BLRI.Manager.Services.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BLRI.API
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
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BLRI API", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"),
                    mig => mig.MigrationsAssembly("BLRI.DAL")));

            services.AddTransient<IServiceUnitOfWork, ServiceUnitOfWork>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ITokenProvider, TokenProvider>();


            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            services.AddAutoMapper();

            services.AddAuthenticationProvider();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("Cors");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BLRI API V1");
            });
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
