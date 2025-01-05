using wpf_ct_sqlSugarTemplate.Models;

namespace wpf_ct_sqlSugarTemplate.Helpers;

public static class MockDataHelper
{
    public static void AddMockUser()
    {

        var userList = new List<User>();
        userList.Add(new User
        {
            UserName = "root",
            Password = "root",
            Role = 0
        });
        userList.Add(new User
        {
            UserName = "test",
            Password = "test",
            Role = 1
        });
        userList.Add(new User
        {
            UserName = "test123",
            Password = "test123",
            Role = 1
        });

        SqlSugarHelper.Db.Insertable(userList).ExecuteCommand();
    }


    public static void AddMockMenu()
    {
        var menuList = new List<Menu>();
        menuList.Add(new Menu()
        {
            MenuName = "首页",
            Icon = "Home",
            View = "IndexView",
            Sort = 1,
        });
        menuList.Add(new Menu()
        {
            MenuName = "设备总控",
            Icon = "Devices",
            View = "DeviceView",
            Sort = 2,
        });
        menuList.Add(new Menu()
        {
            MenuName = "配方管理",
            Icon = "AirFilter",
            View = "FormulaView",
            Sort = 3,
        });
        menuList.Add(new Menu()
        {
            MenuName = "参数管理",
            Icon = "AlphabetCBoxOutline",
            View = "ParamsView",
            Sort = 4,
        });
        menuList.Add(new Menu()
        {
            MenuName = "数据查询",
            Icon = "DataUsage",
            View = "DataQueryView",
            Sort = 5,
        });
        menuList.Add(new Menu()
        {
            MenuName = "数据趋势",
            Icon = "ChartFinance",
            View = "ChartView",
            Sort = 6,
        });
        menuList.Add(new Menu()
        {
            MenuName = "报表管理",
            Icon = "FileReport",
            View = "ReportView",
            Sort = 7,
        });
        menuList.Add(new Menu()
        {
            MenuName = "日志管理",
            Icon = "NotebookOutline",
            View = "LogView",
            Sort = 8,
        });
        menuList.Add(new Menu()
        {
            MenuName = "用户管理",
            Icon = "UserMultipleOutline",
            View = "UserView",
            Sort = 9,
        });

        SqlSugarHelper.Db.Insertable(menuList).ExecuteCommand();
    }
}