using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.CommandEntities;

public class LineItem : Entity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Guid OrderId { get; private set; }
    private LineItem(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    internal static LineItem Create(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("مقدار وارد شده برای تعداد خط سفارش نامعتبر است.");

        return new LineItem(productId, quantity);
    }

    internal void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new Exception("مقدار وارد شده برای تعداد خط سفارش نامعتبر است.");

        Quantity += quantity;
    }
}
