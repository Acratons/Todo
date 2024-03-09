using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.share.Parameters
{
    public class QueryParameter
    {
        private string search = string.Empty;

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get => search; set => search=value; }
    }
}
