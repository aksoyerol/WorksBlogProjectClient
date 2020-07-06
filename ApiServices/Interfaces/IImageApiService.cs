using System.Threading.Tasks;

namespace WorksBlogProjectClient.ApiServices.Interfaces
{
    public interface IImageApiService
    {
        Task<string> GetBlogByImageId(int id);
    }
}