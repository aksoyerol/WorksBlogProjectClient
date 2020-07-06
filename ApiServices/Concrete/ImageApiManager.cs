using System;
using System.Net.Http;
using System.Threading.Tasks;
using WorksBlogProjectClient.ApiServices.Interfaces;

namespace WorksBlogProjectClient.ApiServices.Concrete
{
    public class ImageApiManager : IImageApiService
    {
        private readonly HttpClient _httpClient;
        public ImageApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:57240/api/images/");
        }

        public async Task<string> GetBlogByImageId(int id){
            var responseMessage = await _httpClient.GetAsync($"GetBlogByImageId/{id}");
            if(responseMessage.IsSuccessStatusCode){
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }

    }
}