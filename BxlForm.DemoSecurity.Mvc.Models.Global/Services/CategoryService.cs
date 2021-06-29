using BxlForm.DemoSecurity.Mvc.Models.Global.Data;
using BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Category> Get()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync("api/category").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Category[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Category Get(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/category/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public bool Insert(Category category)
        {
            string json = JsonSerializer.Serialize(category);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/category/", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public bool Update(int id, Category category)
        {
            string json = JsonSerializer.Serialize(category);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/category/{id}", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public bool Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/category/{id}").Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
