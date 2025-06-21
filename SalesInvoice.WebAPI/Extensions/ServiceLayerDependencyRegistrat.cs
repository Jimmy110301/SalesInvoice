using Microsoft.Extensions.DependencyInjection.Extensions;
using SalesInvoice.Service.Contract;
using SalesInvoice.Service.Core;

namespace SalesInvoice.WebAPI.Extensions
{
    public static class ServiceLayerDependencyRegistrat
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile<MappingProfile>();
            });


            services.TryAddSingleton<IDataMapper, AutoMapperDataMapper>();

            // INFO: Below lines will register all the services
            typeof(ICategoryService).Assembly.GetTypes()
                .Where(s => s.Name.EndsWith("Service") && !s.IsInterface && !s.IsAbstract)
                .Select(s => new
                {
                    Type = s,
                    Interface = s.GetInterface($"I{s.Name}")
                })
                .Where(s => s.Interface != null)
                .ToList()
                .ForEach(s =>
                {
                    services.TryAddScoped(s.Interface, s.Type);
                });
        }
    }
}
