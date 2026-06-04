using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
{
    private readonly ICategoryWriteRepository _repository;

    public CreateCategoryCommandHandler(ICategoryWriteRepository repository)
        => _repository = repository;

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);
        await _repository.AddAsync(category, request.ProductIds ?? Array.Empty<int>());

        return Unit.Value;
    }
}
