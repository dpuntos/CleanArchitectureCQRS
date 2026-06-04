using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponseDto>
{
    private readonly IProductReadRepository _readRepository;

    public GetProductQueryHandler(IProductReadRepository readRepository)
        => _readRepository = readRepository;

    public async Task<GetProductQueryResponseDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var model = await _readRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Product {request.Id} not found.");

        return new GetProductQueryResponseDto
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price
        };
    }
}
