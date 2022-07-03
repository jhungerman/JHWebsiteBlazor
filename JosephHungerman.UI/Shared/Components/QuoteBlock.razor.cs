using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.Shared.Models.Enums;
using JosephHungerman.UI.Services.Quote;
using Microsoft.AspNetCore.Components;

namespace JosephHungerman.UI.Shared.Components;

public partial class QuoteBlock
{
    [Inject] private IQuoteService? QuoteService { get; set; }
    [Parameter] public PageType PageType { get; set; }

    private QuoteDto? Quote { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (QuoteService.Quotes == null)
        {
            await QuoteService.GetQuotesAsync();
        }

        Quote = QuoteService.Quotes!.FirstOrDefault(q => q.PageType == PageType);
    }
}