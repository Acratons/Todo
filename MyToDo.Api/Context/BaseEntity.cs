namespace MyToDo.Api.Context
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime UpdateData { get; set; }
    }
}