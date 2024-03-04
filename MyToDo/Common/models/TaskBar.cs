using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.models
{
    /// <summary>
    /// index小卡片任务栏
    /// </summary>
    public class TaskBar : BindableBase
    {
        private String icon;
        private String title;
        private String content;
        private String color;

        //点击触发功能（命名空间）
        private String target;

        public string Title { get => title; set => title=value; }
        public string Icon { get => icon; set => icon=value; }
        public string Content { get => content; set => content=value; }
        public string Color { get => color; set => color=value; }
        public string Target { get => target; set => target=value; }

        public TaskBar(string icon, string title, string content, string color, string target)
        {
            this.icon=icon;
            this.title=title;
            this.content=content;
            this.color=color;
            this.target=target;
        }

        public TaskBar()
        {
        }
    }
}