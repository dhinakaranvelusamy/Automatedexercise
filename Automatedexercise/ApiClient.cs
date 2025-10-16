using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace AutomatedExercise
{
    class ApiClient
    {
        public static async Task<string> PostJsonAsync<T>(string url, T data)
        {
            using HttpClient client = new HttpClient();

            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =  await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }

    public class EmailModel
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string GmailAppPassword { get; set; }
    }
}


