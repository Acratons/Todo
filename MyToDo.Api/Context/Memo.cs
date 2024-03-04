namespace MyToDo.Api.Context
{
    public class Memo : BaseEntity
    {
        public string Title { set; get; }
        public string Content { set; get; }
    }
}