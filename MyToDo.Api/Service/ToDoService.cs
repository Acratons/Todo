﻿using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.share.Dtos;
using MyToDo.share.Parameters;

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
                //数据传输层entity与数据实体层ToDo的映射
                var todo = mapper.Map<ToDo>(entity);

                todo.CreateData = DateTime.Now;
                todo.UpdateData = DateTime.Now;

                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
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
                //var save = unitOfWork.SaveChangesAsync();

                var res = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                response.Delete(res);
                if (await unitOfWork.SaveChangesAsync()>0)
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

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var response = unitOfWork.GetRepository<ToDo>();
                var todos =await response.GetPagedListAsync(predicate:
                   x => string.IsNullOrWhiteSpace(parameter.Search)?true: x.Title.Equals(parameter.Search),
                   pageIndex:parameter.PageIndex,
                   pageSize:parameter.PageSize,
                   orderBy:source => source.OrderByDescending(t => t.CreateData));

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
                //数据传输层entity与数据实体层ToDo的映射
                var dbTodo = mapper.Map<ToDo>(entity);

                var response = unitOfWork.GetRepository<ToDo>();

                var singleTodo = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbTodo.Id));
                singleTodo.Title = dbTodo.Title;
                singleTodo.Content = dbTodo.Content;
                singleTodo.Status = dbTodo.Status;
                singleTodo.UpdateData = DateTime.Now;

                response.Update(singleTodo);

                if (await unitOfWork.SaveChangesAsync()>0)
                    return new ApiResponse(true, dbTodo);
                return new ApiResponse("更新数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
