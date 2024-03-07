namespace MyToDo.Api.Context
{
    public class ToDo : BaseEntity
    {
        public string Title { set; get; }
        public string Content { set; get; }

        public int Status { set; get; }
    }
}