using MyToDo.Common.models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyToDo.Common.models.MemoDto;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        public IndexViewModel()
        {
            //创建实例
            TaskBars = new ObservableCollection<TaskBar>();
            CreatTaskBars();

            CreatTestData();
        }

        /// <summary>
        /// 动态集合管理任务栏
        /// </summary>
        private ObservableCollection<TaskBar> taskBars;

        /// <summary>
        /// RaisePropertyChanged prism的通知功能
        /// </summary>
        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 动态代办事项
        /// </summary>
        private ObservableCollection<ToDoDto> toDoDtos;

        /// <summary>
        /// RaisePropertyChanged prism的通知功能
        /// </summary>
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 动态集合管理备忘录
        /// </summary>
        private ObservableCollection<MemoDto> memoDtos;

        /// <summary>
        /// RaisePropertyChanged prism的通知功能
        /// </summary>
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        private void CreatTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            CreatMemoDtos();
            CreatToDoDtos();
        }

        private void CreatTaskBars()
        {
            TaskBars.Add(new TaskBar("ClockFast", "汇总", "99", "#5994fd", "d"));
            TaskBars.Add(new TaskBar("ClockCheckOutLine", "已完成", "12", "#ff936a", "d"));
            TaskBars.Add(new TaskBar("ChartLineVariant", "汇总", "1%", "#d06f98", "d"));
            TaskBars.Add(new TaskBar("PlaylistStar", "已完成", "41", "#c7f2fc", "d"));
        }

        private void CreatMemoDtos()
        {
            MemoDtos.Add(new MemoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            MemoDtos.Add(new MemoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            MemoDtos.Add(new MemoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
            MemoDtos.Add(new MemoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            MemoDtos.Add(new MemoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            MemoDtos.Add(new MemoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
            MemoDtos.Add(new MemoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            MemoDtos.Add(new MemoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            MemoDtos.Add(new MemoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
            MemoDtos.Add(new MemoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            MemoDtos.Add(new MemoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            MemoDtos.Add(new MemoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
            MemoDtos.Add(new MemoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            MemoDtos.Add(new MemoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            MemoDtos.Add(new MemoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
        }

        private void CreatToDoDtos()
        {
            ToDoDtos.Add(new ToDoDto() { Title="买菜", State=1, Content="去农贸市场买菠菜" });
            ToDoDtos.Add(new ToDoDto() { Title="买肉", State=0, Content="去农贸市场买肉" });
            ToDoDtos.Add(new ToDoDto() { Title="买饭", State=0, Content="去南方小炒吃饭" });
        }
    }
}