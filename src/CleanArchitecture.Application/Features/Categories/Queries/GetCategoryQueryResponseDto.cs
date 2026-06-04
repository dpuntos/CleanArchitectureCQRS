namespace CleanArchitecture.Application.Features.Categories.Queries;

public class GetCategoryQueryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IReadOnlyCollection<GetCategoryProductDto> Products { get; set; } = Array.Empty<GetCategoryProductDto>();
}

public class GetCategoryProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
