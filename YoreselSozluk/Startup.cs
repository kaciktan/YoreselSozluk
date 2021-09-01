using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Concrete;
using YoreselSozluk.Middlewares;
using YoreselSozluk.Services;

namespace YoreselSozluk
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Tokeni kimler kullanabilir
                    ValidateAudience = true,
                    //Token daðýtýcýsýný kontrol et
                    ValidateIssuer = true,
                    //Token süresi dolduðunda geçersiz olsun
                    ValidateLifetime = true,
                    //tokeni kriptoladýðýmýz anahtar keyi kontrol et
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    //Sunucunun time zone u ile tokeni kullanan clientin zamanfarkýnda erken sonlanmamasý için zaman ekliyoruz
                    ClockSkew = TimeSpan.Zero

                };
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoreselSozluk", Version = "v1" });
            });

            services.AddDbContext<Context>(option => option.UseMySQL(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<ILoggerService, ConsoleLogger>();

            services.AddScoped<IContext>(provider => provider.GetService<Context>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YoreselSozluk v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCustomExeptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
