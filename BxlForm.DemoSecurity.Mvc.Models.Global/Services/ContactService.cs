using BxlForm.DemoSecurity.Mvc.Models.Global.Data;
using BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Services
{
    public class ContactService : IContactRepository
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Contact> Get()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync("api/contact").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Contact[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Contact Get(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/contact/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Contact>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public void Insert(Contact contact)
        {
            string json = JsonSerializer.Serialize(contact);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/contact/", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Update(int id, Contact contact)
        {
            string json = JsonSerializer.Serialize(contact);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/contact/{id}", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/contact/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
