using _2.ChatApp.ViewModels.Message;

namespace _2.ChatApp.ViewModels.Chat;

public class ChatViewModel
{
    public MessageViewModel CurrentMessage { get; set; } = null!;

    public List<MessageViewModel> Messages { get; set; } = null!;
}
