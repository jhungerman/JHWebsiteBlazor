using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Services.About;
using JosephHungerman.UI.Services.Quote;
using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Pages;

public partial class About
{
    [Inject] private IAboutService? AboutService { get; set; }
    [Inject] private IToastService? ToastService { get; set; }
    private bool _isLoading = true;

    private List<SectionDto>? Sections { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (AboutService?.Sections == null)
        {
            await AboutService.GetSectionsAsync();
        }

        if (AboutService.DisplayMessage == null)
        {
            Sections = AboutService.Sections;
        }
        else
        {
            ToastService.ShowToast(AboutService.DisplayMessage, ToastLevel.Error);
        }

        _isLoading = false;
    }
}