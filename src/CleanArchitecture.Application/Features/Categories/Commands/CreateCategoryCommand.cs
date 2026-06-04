using MediatR;

namespace CleanArchitecture.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string Name, IReadOnlyCollection<int> ProductIds) : IRequest<Unit>;
