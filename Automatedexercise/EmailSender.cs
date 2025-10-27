using System;
using RestAPIClient;

namespace AutomatedExercise
{
    class EmailSender
    {
        public void Emailsend()
        {
            // Build email model
            var emailModel = new EmailModel
            {
                FromAddress = "velusamy.dhina@gmail.com",
                ToAddress = "v.dhinakran488@gmail.com",
                Subject = "Test Email",
                Content = "Hello from Console App!",
                GmailAppPassword = "geeg ypmd mbai icxo"
            };

            string url = "api/email"; // endpoint part only
            var apiClient = new MyApiClient("https://localhost:44355");

            try
            {
                // 🔹 Run the async POST synchronously
                string response = apiClient.PostDataAsync(url, emailModel).Result;

                Console.WriteLine("Email sent successfully!");
                Console.WriteLine($"Server Response: {response}");
            }
            catch (AggregateException ex)
            {
                // When using .Result, exceptions are wrapped in AggregateException
                Console.WriteLine($" Error sending email: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

}