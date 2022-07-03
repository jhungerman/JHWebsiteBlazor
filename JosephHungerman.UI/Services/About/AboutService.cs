using System.Net.Http.Json;
using JosephHungerman.Shared.Models;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Static;

namespace JosephHungerman.UI.Services.About;

public class AboutService : IAboutService
{
    private readonly HttpClient _client;

    public AboutService(HttpClient client)
    {
        _client = client;
    }

    public List<SectionDto>? Sections { get; set; }
    public string? DisplayMessage { get; set; }

    public async Task GetSectionsAsync()
    {
        try
        {
            if (Sections == null)
            {
                var response = await _client.GetFromJsonAsync<ServiceResponse<List<SectionDto>>>(ApiEndpoints.AboutEndpoint);

                if (response is { Content: { } })
                {
                    Sections = response.Content;
                }
                else
                {
                    DisplayMessage = response?.StatusMessage;
                }
            }
        }
        catch (Exception)
        {
            DisplayMessage = "Something went wrong. About sections cannot be displayed";
        }
    }
}