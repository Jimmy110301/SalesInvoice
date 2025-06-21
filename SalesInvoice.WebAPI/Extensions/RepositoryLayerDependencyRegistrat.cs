using Microsoft.Extensions.DependencyInjection.Extensions;
using SalesInvoice.Repository.Contract;

namespace SalesInvoice.WebAPI.Extensions
{
    public static class RepositoryLayerDependencyRegistrat
    {
        public static void AddRepositoryLayer(this IServiceCollection services)
        {
            // INFO: Below lines will register all the repositories
            typeof(ICategoryRepository).Assembly.GetTypes()
                .Where(s => s.Name.EndsWith("Repository") && !s.IsInterface
                && !s.IsAbstract
                )
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
