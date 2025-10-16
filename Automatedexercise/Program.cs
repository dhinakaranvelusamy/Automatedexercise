 using AutomatedExercise;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Mail;
using JasonLibrary;
using DataAccessLayer;
using StudentInFormation;
using System.Net.Http;
using System.Text.Json;


namespace Automatedexercise
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var emailModel = new EmailModel
            {
                FromAddress = "velusamy.dhina@gmail.com",
                ToAddress = "v.dhinakran488@gmail.com",
                Subject = "Test Email",
                Content = "Hello from Console App!",
                GmailAppPassword = "geeg ypnd mbai icxo"
            };

            string url = "https://localhost:44355/api/email";

            try
            {
                string response = await ApiClient.PostJsonAsync(url, emailModel);
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

    }
}


