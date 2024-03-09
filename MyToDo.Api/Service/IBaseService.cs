using MyToDo.share.Parameters;

namespace MyToDo.Api.Service
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameter query);
        Task<ApiResponse> GetSingleAsync(int id);

        Task<ApiResponse> UpdateAsync(T entity);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse> AddAsync(T entity);
    }
}
