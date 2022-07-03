using JosephHungerman.UI.Shared.Enums;

namespace JosephHungerman.UI.Services.Toast;

public interface IToastService
{
    event Action<string, ToastLevel> OnShow;
    event Action OnHide;
    void ShowToast(string message, ToastLevel level);
}