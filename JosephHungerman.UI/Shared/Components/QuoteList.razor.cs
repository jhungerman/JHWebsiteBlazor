using JosephHungerman.UI.Services.Quote;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Shared.Components;

public partial class QuoteList
{
    [Inject] private IQuoteService QuoteService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await QuoteService.GetQuotesAsync();
    }
}