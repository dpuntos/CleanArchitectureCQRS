using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries;

public record GetProductQualityQuery(int ProductId) : IRequest<ProductQualityReadModel?>;
