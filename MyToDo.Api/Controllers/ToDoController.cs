using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 路由带前缀的api-控制器-方法
    /// [ApiController]特性attribute
    /// </summary>
    [ApiController]
    [Route("api/[ToDoController]/[action]")]
    public class ToDoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /*
        * 工作单元
        */
        public ToDoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork=unitOfWork;
        }



        /// <summary>
        /// 具体业务 控制器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var repository = unitOfWork.GetRepository<ToDo>();
            var todo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id)) ;

            return await Get(id);
        }
    }
}