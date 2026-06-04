using MediatR;

namespace CleanArchitecture.Application.Features.Categories.Queries;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryQueryResponseDto>
{
    private readonly ICategoryReadRepository _readRepository;

    public GetCategoryQueryHandler(ICategoryReadRepository readRepository)
        => _readRepository = readRepository;

    public async Task<GetCategoryQueryResponseDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var model = await _readRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Category {request.Id} not found.");

        return new GetCategoryQueryResponseDto
        {
            Id = model.Id,
            Name = model.Name,
            Products = model.Products
                .Select(p => new GetCategoryProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList()
        };
    }
}
