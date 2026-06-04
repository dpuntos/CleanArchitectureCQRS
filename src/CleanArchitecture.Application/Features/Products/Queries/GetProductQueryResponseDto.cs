namespace CleanArchitecture.Application.Features.Products.Queries;

public class GetProductQueryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
