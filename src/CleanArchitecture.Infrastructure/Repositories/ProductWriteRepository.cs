using CleanArchitecture.Application.Features.Products.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DbContexts;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ProductWriteRepository : IProductWriteRepository
{
    private readonly ProductDbContext _context;

    public ProductWriteRepository(ProductDbContext context) => _context = context;

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}
