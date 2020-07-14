using System.Collections.Generic;
using System.Threading.Tasks;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<CategoryListModel> GetByIdAsync(int id);
        Task<List<CategoryListModel>> GetAllAsync();
        Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCount();
        Task InsertAsync(CategoryAddModel categoryAddModel);
        Task UpdateAsync(CategoryUpdateModel categoryUpdateModel);
        Task DeleteAsync(int id);
    }
}