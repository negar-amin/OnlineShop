namespace OnlineShop.Domain.CommandEntities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public ICollection<LineItem> LineItems { get; private set; }
}
