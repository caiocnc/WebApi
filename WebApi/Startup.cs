using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.Config;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.IoC;
using WebApi.Repository;
using WebApi.Token;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ContextBase>();


            // Interfaces e Repositórios
          

            // Autenticador
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                         .AddJwtBearer(option =>
                         {
                             option.TokenValidationParameters = new TokenValidationParameters
                             {
                                 ValidateIssuer = false,
                                 ValidateAudience = false,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,

                                 ValidIssuer = "Teste.Security.Bearer",
                                 ValidAudience = "Teste.Security.Bearer",
                                 IssuerSigningKey = JwtSecurityKey.Create("43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%")
                             };

                             option.Events = new JwtBearerEvents
                             {
                                 OnAuthenticationFailed = context =>
                                 {
                                     Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                     return Task.CompletedTask;
                                 },
                                 OnTokenValidated = context =>
                                 {
                                     Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                     return Task.CompletedTask;
                                 }
                             };
                         });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
