using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace MyToDo.Api.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        //原本是DbContext ，MyToDoContext继承了这里引用 
        public MemoRepository(MyToDoContext dbContext) : base(dbContext)
        {
        }
    }
}
