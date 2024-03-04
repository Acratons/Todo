using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.models
{
    /// <summary>
    /// 代办事项
    /// </summary>
    public class ToDoDto : BaseDto
    {
        private string title;

        /// <summary>
        /// 状态
        /// </summary>
        private int state;

        private string content;

        public int State { get => state; set => state=value; }
        public string Title { get => title; set => title=value; }
        public string Content { get => content; set => content=value; }
    }
}