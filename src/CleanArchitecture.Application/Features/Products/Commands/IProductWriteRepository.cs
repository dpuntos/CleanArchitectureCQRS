using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Products.Commands;

public interface IProductWriteRepository
{
    Task AddAsync(Product product);
}
