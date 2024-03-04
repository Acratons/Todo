using MyToDo.Common.models;
using MyToDo.Extention;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            menuBars = new ObservableCollection<MenuBar>();
            CreatMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal!=null && journal.CanGoBack)
                {
                    journal.GoBack();
                }
            });

            GoForwordCommand = new DelegateCommand(() =>
            {
                if (journal!=null && journal.CanGoForward)
                {
                    journal.GoForward();
                }
            });
            this.regionManager = regionManager;
        }

        //驱动界面切换导航
        private void Navigate(MenuBar obj)
        {
            //bar不在或者命名空间为空不让导航
            if (obj == null || String.IsNullOrWhiteSpace(obj.NameSpace)) { return; }

            //根据title找到这个区域request
            //返回结果回调委托时间 实例化
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {//每次导航后  不停改变实际状态
                journal = back.Context.NavigationService.Journal;
            });
        }

        //驱动整个导航
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwordCommand { get; private set; }

        private ObservableCollection<MenuBar> menuBars;

        //区域管理
        private readonly IRegionManager regionManager;

        //区域导航日志
        private IRegionNavigationJournal journal;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private void CreatMenuBar()
        {
            menuBars.Add(new MenuBar() { Icon="Home", Title="首页", NameSpace="IndexView" });
            menuBars.Add(new MenuBar() { Icon="Note", Title="待办事项", NameSpace="ToDoView" });
            menuBars.Add(new MenuBar() { Icon="NotePlus", Title="备忘录", NameSpace="MemoView" });
            menuBars.Add(new MenuBar() { Icon="Cog", Title="设置", NameSpace="SettingView" });
        }
    }
}