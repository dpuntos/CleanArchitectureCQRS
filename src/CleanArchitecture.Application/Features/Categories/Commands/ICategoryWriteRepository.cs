using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Categories.Commands;

public interface ICategoryWriteRepository
{
    Task AddAsync(Category category, IReadOnlyCollection<int> productIds);
}
