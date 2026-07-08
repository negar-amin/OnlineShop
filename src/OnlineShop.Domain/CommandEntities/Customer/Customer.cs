using OnlineShop.Domain.Common;
using OnlineShop.Domain.ValueObjects;

namespace OnlineShop.Domain.CommandEntities;

public class Customer : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    private Customer()
    {
        
    }
    private Customer(string firstName, string lastName, PhoneNumber phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        AddDomainEvent(new CustomerCreatedDomainEvent(Id));
    }
    public static Customer Create(string firstName, string lastName, PhoneNumber phoneNumber)
    {
        var customer = new Customer(firstName, lastName, phoneNumber);
        return customer;
    }
}
public sealed class CustomerCreatedDomainEvent : IDomainEvent
{
    public Guid CustomerId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public CustomerCreatedDomainEvent(Guid customerId)
    {
        CustomerId = customerId;
    }
}