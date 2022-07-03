using System.Net.Http.Json;
using JosephHungerman.Shared.Models;
using JosephHungerman.Shared.Models.Dtos;
using JosephHungerman.UI.Static;

namespace JosephHungerman.UI.Services.Contact;

public class ContactService : IContactService
{
    private readonly HttpClient _client;

    public ContactService(HttpClient client)
    {
        _client = client;
    }

    public string? DisplayMessage { get; set; }
    public bool SendSuccessful { get; set; }
    public async Task SendMessageAsync(MessageDto message)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(ApiEndpoints.ContactEndpoint, message);

            if (!response.IsSuccessStatusCode)
            {
                ServiceResponse<MessageDto>? responseDto =
                    await response.Content.ReadFromJsonAsync<ServiceResponse<MessageDto>>();
                DisplayMessage = responseDto?.StatusMessage;
                SendSuccessful = false;
            }
            else
            {
                DisplayMessage = "Email Sent Successfully";
                SendSuccessful = true;
            }

        }
        catch (Exception)
        {
            SendSuccessful = false;
            DisplayMessage = "Something went wrong. Email could not be sent";
        }
    }
}