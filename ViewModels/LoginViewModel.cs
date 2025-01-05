using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using wpf_ct_sqlSugarTemplate.Helpers;
using wpf_ct_sqlSugarTemplate.Messages;
using wpf_ct_sqlSugarTemplate.Models;
using wpf_ct_sqlSugarTemplate.Services;

namespace wpf_ct_sqlSugarTemplate.ViewModels;

public partial class LoginViewModel:ObservableObject
{
    public UserSession UserSessionProp { get;  }
    public LoginViewModel(UserSession userSessionProp)
    {
        UserSessionProp = userSessionProp;
    }
    [ObservableProperty]
    string _userName = "test";

    [ObservableProperty] 
    string _userPass = "test";

    [RelayCommand]
    public void Login()
    {
        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPass))
        {
            MessageBox.Show("用户名或密码为空");
            return;
        }
        // 如果不为空，查询是否在数据库中，如果不在数据库中则弹窗提醒
        var userList = SqlSugarHelper.Db.Queryable<User>().Where(x => x.UserName == UserName
                                                                      && x.Password == UserPass).ToList();
        if (userList.Count > 0)
        {
            // 登录成功的提示
            UserSessionProp.CurrentUser = userList[0];

            // 进行跳转到主界面，消息通知
            WeakReferenceMessenger.Default.Send(new LoginMessage(userList[0]));
        }
        else
        {
            MessageBox.Show("用户名或密码错误！");
        }
    }
}