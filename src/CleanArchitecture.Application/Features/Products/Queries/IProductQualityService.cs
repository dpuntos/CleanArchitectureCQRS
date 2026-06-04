namespace CleanArchitecture.Application.Features.Products.Queries;

public interface IProductQualityService
{
    Task<ProductQualityReadModel?> GetQualityByProductIdAsync(int productId);
}
