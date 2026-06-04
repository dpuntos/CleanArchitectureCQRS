using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries;

public class GetProductQualityQueryHandler : IRequestHandler<GetProductQualityQuery, ProductQualityReadModel?>
{
    private readonly IProductQualityService _qualityService;

    public GetProductQualityQueryHandler(IProductQualityService qualityService)
        => _qualityService = qualityService;

    public async Task<ProductQualityReadModel?> Handle(GetProductQualityQuery request, CancellationToken cancellationToken)
        => await _qualityService.GetQualityByProductIdAsync(request.ProductId);
}
