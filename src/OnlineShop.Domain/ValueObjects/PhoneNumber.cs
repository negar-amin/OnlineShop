using OnlineShop.Domain.Common;
using System.Text.RegularExpressions;

namespace OnlineShop.Domain.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    public string Value { get; }

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception("شماره تلفن الزامی است.");

        value = Normalize(value);

        if (!Regex.IsMatch(value, @"^09\d{9}$"))
            throw new Exception("شماره تلفن معتبر نیست.");

        return new PhoneNumber(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    private static string Normalize(string value)
    {
        value = value.Trim();

        // حذف فاصله و خط تیره و پرانتز
        value = value.Replace(" ", "")
                     .Replace("-", "")
                     .Replace("(", "")
                     .Replace(")", "");

        if (value.StartsWith("+98"))
            value = "0" + value.Substring(3);

        else if (value.StartsWith("98"))
            value = "0" + value.Substring(2);

        return value;
    }
    public override string ToString() => Value;
}
