namespace CleanArchitecture.Application.Features.Products.Queries;

public interface IProductReadRepository
{
    Task<ProductReadModel?> GetByIdAsync(int id);
}
