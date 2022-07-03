using System.Net.Http.Json;
using JosephHungerman.Shared.Models;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Static;

namespace JosephHungerman.UI.Services.Resume;

public class ResumeService : IResumeService
{
    private readonly HttpClient _client;

    public ResumeService(HttpClient client)
    {
        _client = client;
    }

    public ResumeDto? Resume { get; set; }
    public string? DisplayMessage { get; set; }
    public async Task GetResumeAsync()
    {
        try
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<ResumeDto>>
                           (ApiEndpoints.ResumeEndpoint);

            if (response is { Content: { } })
            {
                Resume = response.Content;
            }
            else
            {
                DisplayMessage = response?.StatusMessage;
            }
        }
        catch (Exception)
        {
            DisplayMessage = "Something went wrong. Resume cannot be displayed";
        }
    }
}