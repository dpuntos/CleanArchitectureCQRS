using CleanArchitecture.Application.Features.Products.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace CleanArchitecture.Tests;

public class CreateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Persist_Save_Event_And_Publish()
    {
        // Arrange
        var repo = new Mock<IProductWriteRepository>();
        var store = new Mock<IEventStore>();
        var mediator = new Mock<IMediator>();
        var handler = new CreateProductCommandHandler(repo.Object, store.Object, mediator.Object);
        var command = new CreateProductCommand("Producto 1", 100);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
        repo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        store.Verify(s => s.SaveEventAsync(It.IsAny<ProductCreatedEvent>(), It.IsAny<Guid>()), Times.Once);
        mediator.Verify(m => m.Publish(It.IsAny<ProductCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
