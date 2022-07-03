using JosephHungerman.Shared.Models.Dtos;

namespace JosephHungerman.UI.Services.Resume;

public interface IResumeService
{
    public ResumeDto? Resume { get; set; }
    public string? DisplayMessage { get; set; }
    Task GetResumeAsync();
}