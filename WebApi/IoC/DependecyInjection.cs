using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ContextBase>(options =>
                                        options.UseSqlServer(
                                            ObterStringConexao()));
            TransientServices(services);
            Repositories (services);
            return services;
        }
        private static void TransientServices(IServiceCollection services) 
        { 
            services.AddTransient<IProductService, ProductService>();
        }
        private static void Repositories(IServiceCollection services) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        private static string ObterStringConexao()
        {
            return "Data Source=NBQSP-FC693;Initial Catalog=CAIO_NET_CORE;Integrated Security=False;User ID=CBT;Password=cbt123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            //return "Data Source=NBQSP-FC693;Initial Catalog=CAIO_NET_CORE;Integrated Security=True"; // Conexão Direta, Evitar
        }
    }
}
