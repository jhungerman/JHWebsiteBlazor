using System.ComponentModel;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Services.Contact;
using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Shared.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace JosephHungerman.UI.Pages;

public partial class Contact
{
    [Inject] IJSRuntime JSRuntime { get; set; }
    [Inject] IContactService ContactService { get; set; }
    [Inject] IToastService ToastService { get; set; }
    private MessageDto? _message = new();
    private string captchaResponse;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeAsync<int>("googleRecaptcha", DotNetObjectReference.Create(this), "g-recaptcha",
                "6Ld5omAfAAAAAO1Q_6-0Y94WQOEW51ZH_-dnpTNc");
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    [JSInvokable, EditorBrowsable(EditorBrowsableState.Never)]
    public async Task CallbackOnSuccess()
    {
        await JSRuntime.InvokeVoidAsync("enableBtn");
    }

    private async Task HandleValidSubmit()
    {
        await ContactService.SendMessageAsync(_message);

        ToastService.ShowToast(ContactService.DisplayMessage,
            ContactService.SendSuccessful ? ToastLevel.Success : ToastLevel.Error);

        if (ContactService.SendSuccessful)
        {
            _message = new MessageDto();

            StateHasChanged();
        }
    }
}