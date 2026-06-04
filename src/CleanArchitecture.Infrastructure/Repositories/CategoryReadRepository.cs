using CleanArchitecture.Application.Features.Categories.Queries;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class CategoryReadRepository : ICategoryReadRepository
{
    private readonly ProductDbContext _context;

    public CategoryReadRepository(ProductDbContext context) => _context = context;

    public async Task<CategoryReadModel?> GetByIdAsync(int id)
        => await _context.Categories
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CategoryReadModel(
                c.Id,
                c.Name,
                c.Products
                    .Select(p => new CategoryProductReadModel(p.Id, p.Name, p.Price))
                    .ToList()))
            .FirstOrDefaultAsync();
}
