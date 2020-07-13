using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WorksBlogProjectClient.ApiServices.Interfaces;
using WorksBlogProjectClient.Extensions;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.ApiServices.Concrete
{
    public class BlogApiManager : IBlogApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public BlogApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:57240/api/blogs/");
        }
        public async Task<List<BlogListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BlogListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<BlogListModel> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BlogListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<List<BlogListModel>> GetAllByCategoryIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetAllByCategoryId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BlogListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task InsertAsync(BlogAddModel blogAddModel)
        {
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();
            if (blogAddModel.FormFile != null)
            {
                var bytes = await System.IO.File.ReadAllBytesAsync(blogAddModel.FormFile.FileName);
                ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(blogAddModel.FormFile.ContentType);
                formDataContent.Add(byteArrayContent, nameof(blogAddModel.FormFile), blogAddModel.FormFile.FileName);
            }

            var user = _httpContextAccesor.HttpContext.Session.GetObject<AppUserViewModel>("ActiveUser");
            blogAddModel.AppUserId = user.Id;

            formDataContent.Add(new StringContent(blogAddModel.AppUserId.ToString()), nameof(blogAddModel.AppUserId));
            formDataContent.Add(new StringContent(blogAddModel.ShortDescription), nameof(blogAddModel.ShortDescription));
            formDataContent.Add(new StringContent(blogAddModel.Description), nameof(blogAddModel.Description));
            formDataContent.Add(new StringContent(blogAddModel.Title), nameof(blogAddModel.Title));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Berarer", _httpContextAccesor.HttpContext.Session.GetString("Token"));
            await _httpClient.PostAsync("", formDataContent);
        }
    }
}