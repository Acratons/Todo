using Microsoft.AspNetCore.Mvc;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 路由带前缀的api-控制器-方法
    /// </summary>
    [ApiController]
    [Route("api/[ToDoController]/[action]")]
    public class ToDoController : Controller
    {
        public ToDoController(IUnitOfWork)
        {
        }

        /// <summary>
        /// 具体业务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return await Get(id);
        }
    }
}