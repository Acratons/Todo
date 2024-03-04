namespace MyToDo.Common.models
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class BaseDto
    {
        private int id;
        private DateTime dateTimeCreated;
        private DateTime dateTimeModified;

        public int Id { get => id; set => id=value; }
        public DateTime DateTimeCreated1 { get => dateTimeCreated; set => dateTimeCreated=value; }
        public DateTime DateTimeModified { get => dateTimeModified; set => dateTimeModified=value; }
    }
}