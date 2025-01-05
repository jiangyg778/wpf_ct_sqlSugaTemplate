using CommunityToolkit.Mvvm.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.Replication.PgOutput.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_ct_sqlSugarTemplate.Messages;
using wpf_ct_sqlSugarTemplate.Services;
using wpf_ct_sqlSugarTemplate.ViewModels;

namespace wpf_ct_sqlSugarTemplate.Views
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        private UserSession _userSession;
        public ShellView(UserSession userSession)
        {
            InitializeComponent();
            InitData();
            InitChangeLoginAndWindowView();
            _userSession = userSession;
        }

        private void InitChangeLoginAndWindowView()
        {
            container.Content = App.Current.Services.GetService<LoginView>(); // 初始页面

            // 如果登录成功，则跳转到主界面上(来自于 LoginViewModel 的消息注册）
            WeakReferenceMessenger.Default.Register<LoginMessage>(this, (sender, arg) =>
            {
                container.Content = App.Current.Services.GetService<MainView>();
                Width = 1200;
                Height = 800;
                // 设置窗体弹出的坐标位置
                SetWindowLocation();
            });

            // 用户切换
            WeakReferenceMessenger.Default.Register<LogoutMessage>(this, (sender, arg) =>
            {
                _userSession.CurrentUser = new Models.User()
                {

                    UserName = "test",
                    Password = "test"
                };

                container.Content = App.Current.Services.GetService<LoginView>();
                Width = 800;
                Height = 450;
                // 设置窗体弹出的坐标位置
                SetWindowLocation();
            });


        }

        private void InitData()
        {
            DataContext = App.Current.Services.GetService<ShellViewModel>();
        }

        private void SetWindowLocation()
        {
            Left = (SystemParameters.WorkArea.Width - Width) / 3;
            Top = (SystemParameters.WorkArea.Height - Height) / 3;
        }
    }
}
