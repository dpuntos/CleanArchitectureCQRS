namespace CleanArchitecture.Application.Features.Categories.Queries;

public record CategoryProductReadModel(int Id, string Name, decimal Price);

public record CategoryReadModel(int Id, string Name, IReadOnlyCollection<CategoryProductReadModel> Products);
