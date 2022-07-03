using System.Net.Http.Json;
using JosephHungerman.Shared.Models;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Static;

namespace JosephHungerman.UI.Services.Quote;

public class QuoteService : IQuoteService
{
    private readonly HttpClient _client;

    public QuoteService(HttpClient client)
    {
        _client = client;
    }

    public List<QuoteDto>? Quotes { get; set; }
    public async Task GetQuotesAsync()
    {
        var response =
            await _client.GetFromJsonAsync<ServiceResponse<List<QuoteDto>>>($"{ApiEndpoints.QuoteEndpoint}/getall");

        if (response is {Content: { }})
        {
            Quotes = response.Content;
        }
    }
}