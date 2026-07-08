using Microsoft.EntityFrameworkCore;
using OnlineShop.Contracts.Query;

namespace OnlineShop.Infra.Query.Common;

public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : class
{
    private readonly QueryDbContext _context;
    public BaseQueryRepository(QueryDbContext context)
    {
        _context = context;
    }
    public IQueryable<T> Query()
    {
        return _context.Set<T>().AsNoTracking();
    }
}
