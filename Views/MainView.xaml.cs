using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using wpf_ct_sqlSugarTemplate.ViewModels;
using Menu = wpf_ct_sqlSugarTemplate.Models.Menu;

namespace wpf_ct_sqlSugarTemplate.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            InitData();
            InitRegisterMessage();


        }
        private void InitData()
        {
            DataContext = App.Current.Services.GetService<MainViewModel>();
        }
        private void InitRegisterMessage()
        {
            Page.Content = App.Current.Services.GetService<IndexView>();

            WeakReferenceMessenger.Default.Register<Menu>(this, (sender, arg) =>
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var type = assembly.GetType($"{assembly.GetName().Name}.Views.{arg.View}");

                if (type != null)
                {
                    Page.Content = App.Current.Services.GetService(type);
                }
            });
        }
    }
}
