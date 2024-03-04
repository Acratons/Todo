using Microsoft.EntityFrameworkCore;

namespace MyToDo.Api.Context
{
    public class MyToDoContext : DbContext
    {
        /// <summary>
        /// 重构DbContext中的方法
        /// </summary>
        /// <param name="options"></param>
        public MyToDoContext(DbContextOptions<MyToDoContext> options) : base(options)
        {
        }

        /// <summary>
        /// 用EntityFrameworkCore.Sqlite生成迁移文件
        /// </summary>
        public DbSet<User> Users { get; set; }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Memo> Memo { get; set; }
    }
}