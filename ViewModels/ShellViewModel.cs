using CommunityToolkit.Mvvm.ComponentModel;
using wpf_ct_sqlSugarTemplate.Helpers;
using wpf_ct_sqlSugarTemplate.Models;

namespace wpf_ct_sqlSugarTemplate.ViewModels;

public class ShellViewModel : ObservableObject
{
    public ShellViewModel()
    {
        InitData();
    }

    private void InitData()
    {
        if (true)
        {
            // 建库
            //SqlSugarHelper.Db.DbMaintenance.CreateDatabase();
            // 建表
            //SqlSugarHelper.Db.CodeFirst.InitTables<User>();
            //SqlSugarHelper.Db.CodeFirst.InitTables<Menu>();
            // mock注入数据
            // MockDataHelper.AddMockUser();
            //MockDataHelper.AddMockMenu();
        }
      
    }
}