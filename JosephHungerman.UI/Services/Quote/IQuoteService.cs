using JosephHungerman.Shared.Models;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.Shared.Models.Enums;

namespace JosephHungerman.UI.Services.Quote;

public interface IQuoteService
{
    public List<QuoteDto>? Quotes { get; set; }
    public string? DisplayMessage { get; set; }
    Task GetQuotesAsync();
}