namespace OnlineShop.Contracts.Query;

public interface IBaseQueryRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();
}
