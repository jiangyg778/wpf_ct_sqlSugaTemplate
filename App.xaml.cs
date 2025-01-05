using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using Microsoft.Extensions.DependencyInjection;
using wpf_ct_sqlSugarTemplate.Services;
using wpf_ct_sqlSugarTemplate.Views;

namespace wpf_ct_sqlSugarTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; private set; }
        public App()
        {
            Services = ConfigureService();
            this.InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 切换主题 为 AliceBlue
            ThemeManager.Current.ChangeTheme(this,
                ThemeManager.Current.AddTheme(
                    RuntimeThemeGenerator.Current.GenerateRuntimeTheme("Light", Colors.AliceBlue)));

            // ShellView.xaml作为主窗体 
            Services.GetService<ShellView>()?.Show();
        }

        // 做所有依赖注入的事情
        private IServiceProvider? ConfigureService()
        {
            var services = new ServiceCollection();

            // 注入我们需要的服务
            services.AddSingleton<UserSession>(); // 单例

            // 注册所有的 View 和 ViewModel
            RegisterViewsAndViewModels(services);

            return services.BuildServiceProvider();
        }

        private void RegisterViewsAndViewModels(ServiceCollection services)
        {
            var assembly = typeof(App).Assembly; // 获取当前程序集
            var viewTypes = assembly.GetTypes() // 获取所有的类型
                .Where(t => t.Name.EndsWith("View") && !t.IsAbstract)// 筛选出所有的 View
                .ToList();

            foreach (var viewType in viewTypes)
            {
                // 注册 View
                services.AddSingleton(viewType);

                // 查找并注册对应的 ViewModel
                var viewModelName = $"{viewType.Namespace.Replace(".Views", ".ViewModels")}.{viewType.Name}Model";
                var viewModelType = assembly.GetTypes()
                    .FirstOrDefault(t => t.FullName == viewModelName);

                if (viewModelType != null)
                {
                    services.AddSingleton(viewModelType);
                }
            }
        }
    }

}
