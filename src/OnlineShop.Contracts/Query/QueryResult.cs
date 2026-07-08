namespace OnlineShop.Contracts.Query;

public class QueryResult<TData>
{
    public bool IsSuccess { get; }

    public TData Data { get; }

    public string ErrorMessage { get; }

    protected QueryResult(bool isSuccess, TData data = default(TData), string errorMessage = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public static QueryResult<TData> Success(TData data)
    {
        return new QueryResult<TData>(isSuccess: true, data);
    }

    public static QueryResult<TData> Fail(string errorMessage)
    {
        return new QueryResult<TData>(isSuccess: false, default(TData), errorMessage);
    }

    public static QueryResult<TData> Default()
    {
        return new QueryResult<TData>(isSuccess: false);
    }

    public static implicit operator bool(QueryResult<TData> result)
    {
        return result.IsSuccess;
    }
}
