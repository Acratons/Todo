using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.share.Dtos
{
    /// <summary>
    /// 待办事项数据实体
    /// </summary>
    public class ToDoDto :BaseDtos
    {
        private string title;
        private string content;
        private string status;

        public string Title { get =>  title; set  { title=value; OnPropertyChanged(); } }
        public string Content { get => content; set  { content=value; OnPropertyChanged(); } }
        public string Status { get => status; set  { status=value; OnPropertyChanged(); } }
    }
}
