using JosephHungerman.Shared.Models.Dtos;

namespace JosephHungerman.UI.Services.Contact;

public interface IContactService
{
    public string? DisplayMessage { get; set; }
    public bool SendSuccessful { get; set; }
    Task SendMessageAsync(MessageDto message);
}