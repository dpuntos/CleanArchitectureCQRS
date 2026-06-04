using System.Net.Http.Json;
using CleanArchitecture.Application.Features.Products.Queries;

namespace CleanArchitecture.Infrastructure.ExternalServices;

public class ProductQualityService : IProductQualityService
{
    private readonly HttpClient _httpClient;

    public ProductQualityService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ProductQualityReadModel?> GetQualityByProductIdAsync(int productId)
    {
        var response = await _httpClient.GetAsync($"/api/quality/{productId}");

        if (!response.IsSuccessStatusCode)
            return null;

        var quality = await response.Content.ReadFromJsonAsync<int>();
        return new ProductQualityReadModel(productId, quality);
    }
}
