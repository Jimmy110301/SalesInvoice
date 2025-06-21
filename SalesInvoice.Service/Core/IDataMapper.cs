namespace SalesInvoice.Service.Core
{
    public interface IDataMapper
    {
        TDestination MapTo<TSource, TDestination>(TSource source);
        TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination);
        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);
    }
}
