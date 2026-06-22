using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class ApiService
{
    private readonly HttpClient _http = new();
    private const string BaseUrl = "http://localhost:5000/api/products";

    public async Task<List<ProductDto>> GetAllAsync()
        => await _http.GetFromJsonAsync<List<ProductDto>>(BaseUrl) ?? new();

    public async Task<ProductDto?> CreateAsync(ProductDto dto)
    {
        var response = await _http.PostAsJsonAsync(BaseUrl, dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProductDto>();
    }

    public async Task UpdateAsync(ProductDto dto)
    {
        var response = await _http.PutAsJsonAsync($"{BaseUrl}/{dto.Id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
