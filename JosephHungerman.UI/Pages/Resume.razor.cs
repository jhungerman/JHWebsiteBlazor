using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Services.Resume;
using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Pages;

public partial class Resume
{
    [Inject] IResumeService ResumeService { get; set; }
    [Inject] IToastService ToastService { get; set; }

    private ResumeDto? _resume;
    private bool _isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        if (ResumeService?.Resume == null)
        {
            await ResumeService.GetResumeAsync();
        }

        if (ResumeService.DisplayMessage == null)
        {
            _resume = ResumeService.Resume;
        }
        else
        {
            ToastService.ShowToast(ResumeService.DisplayMessage, ToastLevel.Error);
        }

        _isLoading = false;
    }
}