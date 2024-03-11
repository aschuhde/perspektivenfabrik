using System.Text.Json;

namespace Application.FunctionalTests;

public static class CommonExtensions
{
    public static async Task<T?> ReadAsJsonObject<T>(this HttpContent content)
    {
        return JsonSerializer.Deserialize<T>(await content.ReadAsStringAsync());
    }
}