using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries;

public record GetProductQuery(int Id) : IRequest<GetProductQueryResponseDto>;
