using System.Runtime.InteropServices;

namespace OnlineShop.Domain.CommandEntities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public long Price { get; private set; }
    public int Stock { get; private set; }
    private Product(string name, long price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Stock = stock;
    }
    public static Product? Create(string name, long price, int stock)
    {
        if(stock > 0 && price > 0)
        {
            var product = new Product(name, price, stock);
            return product;
        }
        return null;
    }
}
