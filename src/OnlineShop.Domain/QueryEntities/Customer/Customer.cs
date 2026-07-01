namespace OnlineShop.Domain.QueryEntities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
