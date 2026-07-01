namespace OnlineShop.Domain.CommandEntities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    private Customer(string firstName, string lastName, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
    public static Customer Create(string firstName, string lastName, string phoneNumber)
    {
        return new Customer(firstName, lastName, phoneNumber);
    }
}
