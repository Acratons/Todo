using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.share.Dtos;
using MyToDo.share.Parameters;

namespace MyToDo.Api.Service
{
    /// <summary>
    /// 待办事项 
    /// </summary>
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MemoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork=unitOfWork;
            this.mapper=mapper;
        }
        //Task线程方法 并发- -
        public async Task<ApiResponse> AddAsync(MemoDto entity)
        {
            try
            {
                //数据传输层entity与数据实体层ToDo的映射
                var memo = mapper.Map<Memo>(entity);

                //给出数据创建时间
                memo.CreateData = DateTime.Now;
                memo.UpdateData = DateTime.Now;

                //写入数据库
                await unitOfWork.GetRepository<Memo>().InsertAsync(memo);

                //判断数据是否保存
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
                //获取Memo仓储 （用于对数据库进行curd）
                var response = unitOfWork.GetRepository<Memo>();
                
                //根据id获取数据
                var res =await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                response.Delete(res);

                if (await unitOfWork.SaveChangesAsync() > 0)
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
                var response = unitOfWork.GetRepository<Memo>();
                var todos = await response.GetPagedListAsync(predicate:
                   x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Equals(parameter.Search),
                   pageIndex: parameter.PageIndex,
                   pageSize: parameter.PageSize,
                   orderBy: source => source.OrderByDescending(t => t.CreateData));

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
                var response = unitOfWork.GetRepository<Memo>();
                var singleTodo = await response.GetFirstOrDefaultAsync(predicate:x => x.Id.Equals(id));

                return new ApiResponse(true, singleTodo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(MemoDto entity)
        {
            try
            {
                //数据传输层entity与数据实体层ToDo的映射
                var dbMemo = mapper.Map<Memo>(entity);

                var response = unitOfWork.GetRepository<Memo>();

                var singleMemo = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbMemo.Id));
                singleMemo.Title = dbMemo.Title;
                singleMemo.Content = dbMemo.Content;
                //singleTodo.Status = dbMemo.Status;
                singleMemo.UpdateData = DateTime.Now;

                response.Update(singleMemo);

                if (await unitOfWork.SaveChangesAsync()>0)
                    return new ApiResponse(true, dbMemo);
                return new ApiResponse("更新数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
