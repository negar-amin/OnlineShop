using System.Runtime.InteropServices;

namespace OnlineShop.Contracts.Commands.Common;

public class CommandResult<T>
{
    public bool IsSuccess { get; }

    public T Data { get; }

    public List<string> ErrorMessages { get; }

    protected CommandResult(bool isSuccess, T data = default(T), List<string> errorMessages = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessages = errorMessages ?? new List<string>();
    }

    public static CommandResult<T> Success(T data)
    {
        return new CommandResult<T>(isSuccess: true, data);
    }

    public static CommandResult<T> Failure(string errorMessage)
    {
        int num = 1;
        List<string> list = new List<string>(num);
        CollectionsMarshal.SetCount(list, num);
        CollectionsMarshal.AsSpan(list)[0] = errorMessage;
        return new CommandResult<T>(isSuccess: false, default(T), list);
    }

    public static CommandResult<T> Failure(string errorMessage, T data)
    {
        int num = 1;
        List<string> list = new List<string>(num);
        CollectionsMarshal.SetCount(list, num);
        CollectionsMarshal.AsSpan(list)[0] = errorMessage;
        return new CommandResult<T>(isSuccess: false, data, list);
    }

    public static CommandResult<T> Failure(List<string> errorMessages)
    {
        return new CommandResult<T>(isSuccess: false, default(T), errorMessages);
    }

    public static CommandResult<T> Failure(List<string> errorMessages, T data)
    {
        return new CommandResult<T>(isSuccess: false, data, errorMessages);
    }

    public static CommandResult<T> Default()
    {
        return new CommandResult<T>(isSuccess: false);
    }

    public static implicit operator CommandResult<T>(CommandResult result)
    {
        if (result.IsSuccess)
        {
            return Success(default(T));
        }

        return Failure(result.ErrorMessages ?? new List<string>());
    }

    public void AddError(string error)
    {
        ErrorMessages.Add(error);
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        ErrorMessages.AddRange(errors);
    }
}
public class CommandResult
{
    public bool IsSuccess { get; }

    public List<string> ErrorMessages { get; }

    protected CommandResult(bool isSuccess, List<string> errorMessages = null)
    {
        IsSuccess = isSuccess;
        ErrorMessages = errorMessages ?? new List<string>();
    }

    public static CommandResult Default()
    {
        return new CommandResult(isSuccess: false);
    }

    public static CommandResult Success()
    {
        return new CommandResult(isSuccess: true);
    }

    public static CommandResult Failure(string errorMessage)
    {
        int num = 1;
        List<string> list = new List<string>(num);
        CollectionsMarshal.SetCount(list, num);
        CollectionsMarshal.AsSpan(list)[0] = errorMessage;
        return new CommandResult(isSuccess: false, list);
    }

    public static CommandResult Failure(List<string> errorMessages)
    {
        return new CommandResult(isSuccess: false, errorMessages);
    }
}