using BugStore.Domain.Exceptions;

namespace BugStore.Domain.Entities;

public class Customer : Entity
{
    protected Customer(){}
    public Customer(string name, string email, string phone, DateTime birthDate)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(phone) ||
            string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new CustomerException("Parameters in constructor from customer is null or empty!");
        Name = name;
        Email = email;
        Phone = phone;
        BirthDate = birthDate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
}