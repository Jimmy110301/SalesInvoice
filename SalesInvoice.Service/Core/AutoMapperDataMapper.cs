
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace SalesInvoice.Service.Core
{
    public class AutoMapperDataMapper : IDataMapper
    {
        private readonly IMapper mapper;

        public AutoMapperDataMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination MapTo<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>(mapper.ConfigurationProvider);
        }
    }
}
