using Microsoft.EntityFrameworkCore;
using SalesInvoice.Data.Contract;
using SalesInvoice.Data.Implementation;

namespace SalesInvoice.WebAPI.Extensions
{
    public static class DataLayerDependencyRegistrat
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // INFO :: SQL 
            services.AddDbContext<IDataContext, DataContext>(options =>
            {
                options.UseLazyLoadingProxies(true);
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
