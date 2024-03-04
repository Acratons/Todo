namespace MyToDo.Api.Context.Repository
{
    /// <summary>
    /// 仓储目的 基础设施与业务解耦
    /// </summary>
    public interface IToDoRepository
    {
        Task<bool> Add(ToDo toDo);

        Task<bool> Update(ToDo toDo);

        Task<bool> Delete(int id);
    }

    /// <summary>
    /// 实现接口
    /// </summary>
    public class ToDoRepository : IToDoRepository
    {
        private MyToDoContext doContext;

        public ToDoRepository(MyToDoContext doContext)
        {
            this.doContext = doContext;
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="toDo"></param>
        /// <returns></returns>
        public async Task<bool> Add(ToDo toDo)
        {
            await doContext.ToDo.AddAsync(toDo);
            return await doContext.SaveChangesAsync() > 0;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}