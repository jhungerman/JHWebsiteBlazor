using JosephHungerman.Shared.Models.Dtos;

namespace JosephHungerman.UI.Services.About;

public interface IAboutService
{
    public List<SectionDto>? Sections { get; set; }
    public string? DisplayMessage { get; set; }
    Task GetSectionsAsync();
}