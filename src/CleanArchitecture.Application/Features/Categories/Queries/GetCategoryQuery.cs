using MediatR;

namespace CleanArchitecture.Application.Features.Categories.Queries;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryQueryResponseDto>;
