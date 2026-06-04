namespace CleanArchitecture.Application.Features.Categories.Queries;

public interface ICategoryReadRepository
{
    Task<CategoryReadModel?> GetByIdAsync(int id);
}
