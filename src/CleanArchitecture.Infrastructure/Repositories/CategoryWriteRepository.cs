using CleanArchitecture.Application.Features.Categories.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class CategoryWriteRepository : ICategoryWriteRepository
{
    private readonly ProductDbContext _context;

    public CategoryWriteRepository(ProductDbContext context) => _context = context;

    public async Task AddAsync(Category category, IReadOnlyCollection<int> productIds)
    {
        if (productIds.Count > 0)
        {
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            foreach (var product in products)
                category.AddProduct(product);
        }

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
}
