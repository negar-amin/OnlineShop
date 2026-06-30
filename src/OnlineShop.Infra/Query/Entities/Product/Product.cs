namespace OnlineShop.Infra.Query.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public long Price { get; private set; }
    public int Stock { get; private set; }
}
