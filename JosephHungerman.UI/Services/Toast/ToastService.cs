using System.Timers;
using JosephHungerman.UI.Shared.Enums;
using Timer = System.Timers.Timer;

namespace JosephHungerman.UI.Services.Toast;

public class ToastService : IToastService, IDisposable
{
    public event Action<string, ToastLevel>? OnShow;
    public event Action? OnHide;
    private readonly Timer _countdown = new(5000);

    public void ShowToast(string message, ToastLevel level)
    {
        OnShow?.Invoke(message, level);
        StartCountdown();
    }

    private void StartCountdown()
    {
        SetCountdown();

        if (_countdown.Enabled)
        {
            _countdown.Stop();
            _countdown.Start();
        }
        else
        {
            _countdown.Start();
        }
    }

    private void SetCountdown()
    {
        _countdown.Elapsed += HideToast;
        _countdown.AutoReset = false;
    }

    private void HideToast(object? sender, ElapsedEventArgs e)
    {
        OnHide?.Invoke();
    }

    public void Dispose()
    {
        _countdown.Dispose();
    }
}