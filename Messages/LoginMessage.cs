using CommunityToolkit.Mvvm.Messaging.Messages;
using wpf_ct_sqlSugarTemplate.Models;

namespace wpf_ct_sqlSugarTemplate.Messages;

public class LoginMessage:ValueChangedMessage<User>
{
    public LoginMessage(User value) : base(value)
    {
    }
}