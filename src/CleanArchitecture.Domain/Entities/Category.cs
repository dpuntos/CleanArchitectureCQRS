namespace CleanArchitecture.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    private Category()
    {
    }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name;
    }

    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (!_products.Contains(product))
            _products.Add(product);
    }
}
