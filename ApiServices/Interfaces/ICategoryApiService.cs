using System.Collections.Generic;
using System.Threading.Tasks;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.ApiServices.Interfaces{
    public interface ICategoryApiService{
        Task<List<CategoryListModel>> GetAllAsync();
    }
}