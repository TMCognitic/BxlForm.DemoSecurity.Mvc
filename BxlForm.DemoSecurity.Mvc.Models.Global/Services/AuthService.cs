using BxlForm.DemoSecurity.Mvc.Models.Global.Data;
using BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public User Login(string email, string passwd)
        {            
            string json = JsonSerializer.Serialize(new { email, passwd });
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/auth/login", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<User>(httpResponseMessage.Content.ReadAsStringAsync().Result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) : null;
        }

        public void Register(User user)
        {
            string json = JsonSerializer.Serialize(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/auth/login", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
