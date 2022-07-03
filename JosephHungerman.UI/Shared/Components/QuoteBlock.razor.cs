using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.Shared.Models.Enums;
using JosephHungerman.UI.Services.Quote;
using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Shared.Components;

public partial class QuoteBlock
{
    [Inject] private IQuoteService? QuoteService { get; set; }
    [Inject] private IToastService? ToastService { get; set; }
    [Parameter] public PageType PageType { get; set; }

    private QuoteDto? Quote { get; set; }
    private bool _isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        if (QuoteService?.Quotes == null)
        {
            await QuoteService.GetQuotesAsync();
        }

        if (QuoteService.DisplayMessage == null)
        {
            Quote = QuoteService.Quotes!.FirstOrDefault(q => q.PageType == PageType);
        }
        else
        {
            ToastService.ShowToast(QuoteService.DisplayMessage, ToastLevel.Error);
        }

        _isLoading = false;
    }
}