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
    }
    public static Customer Create(string firstName, string lastName, PhoneNumber phoneNumber)
    {
        return new Customer(firstName, lastName, phoneNumber);
    }
}
