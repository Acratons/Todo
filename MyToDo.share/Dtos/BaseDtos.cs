using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.share.Dtos
{
    public class BaseDtos : INotifyPropertyChanged
    {
        public int id {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 实现通知更新
        /// </summary>
        /// <param name="propertyName"> CallerMemberName 自动获取</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName="") 
        {
            //调用事件传递属性名称
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
