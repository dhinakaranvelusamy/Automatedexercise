using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIClient
{
    public class MyApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string baseURL = "https://localhost:44355";

        public MyApiClient()
        {
            _httpClient = new HttpClient();
            // Optional: Configure base address for convenience
            _httpClient.BaseAddress = new Uri(baseURL);
            // Optional: Add default headers
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public MyApiClient(string basUrl)
        {
            _httpClient = new HttpClient();
            // Optional: Configure base address for convenience
            _httpClient.BaseAddress = new Uri(basUrl);
            // Optional: Add default headers
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetDataAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode(); // Throws an exception if the status code is not 2xx

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{endpoint} - {responseBody}");
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<string> PostDataAsync<T>(string endpoint, T data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data); // Or System.Text.Json.JsonSerializer.Serialize
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;

            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<string> PutDataAsync<T>(string endpoint, T data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task DeleteDataAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}