using CommunityToolkit.Mvvm.Messaging.Messages;
using wpf_ct_sqlSugarTemplate.Models;

namespace wpf_ct_sqlSugarTemplate.Messages;

public class LogoutMessage :ValueChangedMessage<User>
{
    public LogoutMessage(User value) : base(value)
    {
    }
}