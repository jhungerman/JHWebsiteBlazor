using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Shared.Components;

public partial class Toast : IDisposable
{
    [Inject] IToastService ToastService { get; set; }

    protected string? Heading { get; set; }
    protected string? Message { get; set; }
    protected bool IsVisible { get; set; }
    protected string? BackgroundCssClass { get; set; }
    protected string? IconCssClass { get; set; }

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;
        ToastService.OnHide += HideToast;
    }

    private void ShowToast(string message, ToastLevel level)
    {
        BuildToastSettings(level, message);
        IsVisible = true;
        StateHasChanged();
    }

    private void HideToast()
    {
        IsVisible = false;
        StateHasChanged();
    }

    private void BuildToastSettings(ToastLevel level, string message)
    {
        switch (level)
        {
            case ToastLevel.Info:
                BackgroundCssClass = "bg-info";
                IconCssClass = "fa-solid fa-info";
                Heading = "Info";
                break;
            case ToastLevel.Success:
                BackgroundCssClass = "bg-success";
                IconCssClass = "fa-solid fa-check";
                Heading = "Success";
                break;
            case ToastLevel.Warning:
                BackgroundCssClass = "bg-warning";
                IconCssClass = "fa-solid fa-exclamation";
                Heading = "Warning";
                break;
            case ToastLevel.Error:
                BackgroundCssClass = "bg-danger";
                IconCssClass = "fa-solid fa-xmark";
                Heading = "Error";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), level, null);
        }

        Message = message;
    }

    public void Dispose()
    {
        ToastService.OnShow -= ShowToast;
    }
}