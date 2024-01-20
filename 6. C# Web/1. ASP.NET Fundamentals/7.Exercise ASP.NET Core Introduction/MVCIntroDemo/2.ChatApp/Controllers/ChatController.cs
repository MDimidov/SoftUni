using _2.ChatApp.ViewModels.Chat;
using Microsoft.AspNetCore.Mvc;

namespace _2.ChatApp.Controllers;

public class ChatController : Controller
{
    private static ICollection<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();
    public IActionResult Index()
    {
        return RedirectToAction("Show");
    }

    [HttpGet]
    public IActionResult Show()
    {
        if(messages.Count() < 1)
        {
            return View(new ChatViewModel());
        }

        var chatModel = new ChatViewModel()
        {
            Messages = messages
            .Select(m => new ViewModels.Message.MessageViewModel()
            {
                Sender = m.Key,
                MessageText = m.Value
            })
            .ToList()
        };

        return View(chatModel);
    }

    [HttpPost]
    public IActionResult Send(ChatViewModel chat)
    {
        var newMessage = chat.CurrentMessage;
        messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
        return RedirectToAction("Show");
    }
}
