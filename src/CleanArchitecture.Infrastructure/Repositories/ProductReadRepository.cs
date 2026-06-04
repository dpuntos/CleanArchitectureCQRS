using CleanArchitecture.Application.Features.Products.Queries;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ProductReadRepository : IProductReadRepository
{
    private readonly ProductDbContext _context;

    public ProductReadRepository(ProductDbContext context) => _context = context;

    public async Task<ProductReadModel?> GetByIdAsync(int id)
        => await _context.Products
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ProductReadModel(p.Id, p.Name, p.Price))
            .FirstOrDefaultAsync();
}
