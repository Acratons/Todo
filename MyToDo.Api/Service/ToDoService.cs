using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.share.Dtos;

namespace MyToDo.Api.Service
{
    /// <summary>
    /// 待办事项 
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork=unitOfWork;
            this.mapper=mapper;
        }

        public async Task<ApiResponse> AddAsync(ToDoDto entity)
        {
            try
            {
                var todo = mapper.Map<Todo>(entity);

                await unitOfWork.GetRepository<ToDo>().InsertAsync(entity);
                if (await unitOfWork.SaveChangesAsync()>0)
                {
                    return new ApiResponse(true, entity);
                }
                return new ApiResponse("添加数据失败");
            }catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var response = unitOfWork.GetRepository<ToDo>();
                var save = unitOfWork.SaveChangesAsync();

                var res =await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                response.Delete(res);
                if (await save>0)
                {
                    return new ApiResponse(true, "删除成功");
                }
                return new ApiResponse("删除失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var response = unitOfWork.GetRepository<ToDo>();
                var todos =await response.GetAllAsync();

                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var response = unitOfWork.GetRepository<ToDo>();
                var singleTodo = await response.GetFirstOrDefaultAsync(predicate:x => x.Id.Equals(id));

                return new ApiResponse(true, singleTodo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(ToDoDto entity)
        {
            try
            {
                var response = unitOfWork.GetRepository<ToDo>();
                var singleTodo = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id));
                singleTodo.Title = entity.Title;
                singleTodo.Content = entity.Content;
                singleTodo.Status = entity.Status;
                singleTodo.UpdateData = DateTime.Now;

                if (await unitOfWork.SaveChangesAsync()>0)
                    return new ApiResponse(true, entity);
                return new ApiResponse("更新数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
