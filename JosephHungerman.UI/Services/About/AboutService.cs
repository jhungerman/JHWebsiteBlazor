using JosephHungerman.Shared.Models.Dtos;

namespace JosephHungerman.UI.Services.About;

public class AboutService : IAboutService
{
    private readonly HttpClient _client;

    public AboutService(HttpClient client)
    {
        _client = client;
    }

    public List<SectionDto>? Sections { get; set; }
    public async Task GetSections()
    {
        if (Sections == null)
        {
            var sections = "";
        }
    }
}