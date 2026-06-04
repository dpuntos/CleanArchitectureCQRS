using CleanArchitecture.Application.Features.Products.Commands;
using CleanArchitecture.Application.Features.Products.Queries;
using CleanArchitecture.Application.Features.Categories.Commands;
using CleanArchitecture.Application.Features.Categories.Queries;
using CleanArchitecture.Infrastructure.DbContexts;
using CleanArchitecture.Infrastructure.EventStore;
using CleanArchitecture.Infrastructure.ExternalServices;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<IEventStore, EventStoreRepository>();

        var qualityApiBaseUrl = configuration["ExternalServices:QualityApi:BaseUrl"]
            ?? "https://api-quality.example.com";

        services.AddHttpClient<IProductQualityService, ProductQualityService>(client =>
        {
            client.BaseAddress = new Uri(qualityApiBaseUrl);
        });

        return services;
    }
}
