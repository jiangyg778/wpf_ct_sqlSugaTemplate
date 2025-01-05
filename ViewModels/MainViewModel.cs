using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using wpf_ct_sqlSugarTemplate.Helpers;
using wpf_ct_sqlSugarTemplate.Models;
using wpf_ct_sqlSugarTemplate.Services;


namespace wpf_ct_sqlSugarTemplate.ViewModels;

public partial class MainViewModel
{
    public UserSession UserSessionProp { get; }
    public List<Menu> MenuEntities { get; set; } = new();


    public MainViewModel(UserSession userSessionProp)
    {
        UserSessionProp = userSessionProp;
        InitData();

    }

    private void InitData()
    {
        MenuEntities = SqlSugarHelper.Db.Queryable<Menu>().ToList();
    }

    [RelayCommand]
    public void Navigation(Menu menu)
    {
        WeakReferenceMessenger.Default.Send(menu);
    }


}