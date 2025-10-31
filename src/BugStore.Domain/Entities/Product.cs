using BugStore.Domain.Exceptions;

namespace BugStore.Domain.Entities;

public class Product : Entity
{
    public Product()
    {
        
    }
    public Product(string title, string description, string slug, decimal price)
    {
        if (string.IsNullOrEmpty(title) ||
            string.IsNullOrEmpty(description) ||
            string.IsNullOrEmpty(slug) ||
            price < 0)
            throw new ProductException();
        Title = title;
        Description = description;
        Slug = slug;
        Price = price;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public decimal Price { get; set; }
}