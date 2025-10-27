using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;

namespace RestAPIClient
{
    public class StudentApiClient
    {
        private readonly HttpClient _httpClient;

        public StudentApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44355/"); // Replace with your actual API base URL
        }

        public async Task<List<StudentInfo>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StudentInfo>>("/api/students");
        }

        public async Task CreateAsync(StudentInfo student)
        {
            await _httpClient.PostAsJsonAsync("/api/students", student);
        }

        public async Task UpdateAsync(int id, StudentInfo student)
        {
            await _httpClient.PutAsJsonAsync($"/api/students/{id}", student);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/students/{id}");
        }

        public async Task<List<StudentInfo>> SearchByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<StudentInfo>>($"/api/students/search/name/{name}");
        }

        public async Task<StudentInfo> SearchByRollNoAsync(int roll)
        {
            return await _httpClient.GetFromJsonAsync<StudentInfo>($"/api/students/search/roll/{roll}");
        }

        public async Task<StudentInfo> SearchByMobileAsync(long mobile)
        {
            return await _httpClient.GetFromJsonAsync<StudentInfo>($"/api/students/search/mobile/{mobile}");
        }
    }
}
