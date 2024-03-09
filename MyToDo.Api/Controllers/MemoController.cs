using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Service;
using MyToDo.share.Dtos;
using MyToDo.share.Parameters;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 备忘录控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")] 
    public class MemoController : ControllerBase
    {
        private readonly IMemoService memoService;

        /*
        * 工作单元
        */
        public MemoController(IMemoService memoService)
        {
            this.memoService=memoService;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await memoService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter parameter) => await memoService.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto model) => await memoService.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model) => await memoService.UpdateAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await memoService.DeleteAsync(id);

    }
}
