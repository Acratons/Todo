using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;
using MyToDo.share.Dtos;
using MyToDo.share.Parameters;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 待办事项控制器
    /// 路由带前缀的api-控制器-方法
    /// [ApiController]特性attribute
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService toDoService;

        /*
        * 工作单元
        */
        public ToDoController(IToDoService toDoService)
        {
            this.toDoService=toDoService;
        }



        /// <summary>
        /// 具体业务 控制器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ApiResponse> Get(int id)
        //{
        //    var res =await toDoService.GetSingleAsync(id);

        //    return new ApiResponse(true,res);
        //}
        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await toDoService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter parameter) => await toDoService.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDoDto model) => await toDoService.AddAsync(model);
         
        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDoDto model) => await toDoService.UpdateAsync(model);
         
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await toDoService.DeleteAsync(id);
    }
}