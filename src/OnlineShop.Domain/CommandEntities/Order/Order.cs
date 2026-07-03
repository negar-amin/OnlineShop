using OnlineShop.Domain.Common;
using System.Runtime.InteropServices;

namespace OnlineShop.Domain.CommandEntities;

public class Order : Entity
{
    private readonly List<LineItem> _lineItems;
    public Guid CustomerId { get; private set; }
    public IReadOnlyCollection<LineItem> LineItems => _lineItems;
    private Order(Guid customerId)
    {
        _lineItems = new List<LineItem>();
        CustomerId = customerId;
    }

    public static Order Create(Guid customerId)
    {
        return new Order(customerId);
    }
    public void AddLineItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("مقدار وارد شده برای تعداد خط سفارش نامعتبر است.");

        var existing = _lineItems.FirstOrDefault(x => x.ProductId == productId);

        if (existing != null)
        {
            existing.IncreaseQuantity(quantity);
            return;
        }

        _lineItems.Add(LineItem.Create(productId, quantity));
    }
}
