using System.Threading.Tasks;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> SignInAsync(AppUserLoginModel appUserLoginModel);
    }

}