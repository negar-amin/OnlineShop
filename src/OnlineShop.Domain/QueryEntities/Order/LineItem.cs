namespace OnlineShop.Domain.QueryEntities;

public class LineItem
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Guid OrderId { get; private set; }
}
