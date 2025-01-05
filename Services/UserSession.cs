using CommunityToolkit.Mvvm.ComponentModel;
using wpf_ct_sqlSugarTemplate.Models;

namespace wpf_ct_sqlSugarTemplate.Services;

public class UserSession:ObservableObject
{
    private User _user = new User() { UserName = "test", Password = "test" };

    public User CurrentUser
    {
        get => _user;
        set => SetProperty(ref _user, value);
    }

}