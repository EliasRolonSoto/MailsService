using Bogus;
using Mails.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.ConsoleApp
{
    public class UserGenerator
    {
        public static void Generate(int amount)
        {
            var faker = new Faker();
            var passwordHasher = new PasswordHasher<string>();
            using (var client = new HttpClient())
            {
                for (int i = 0; i < amount; i++)
                {
                    var user = new User()
                    {
                        Name = faker.Name.FirstName(),
                        Email = faker.Internet.ExampleEmail(),
                        PasswordHash = passwordHasher.HashPassword(null!, faker.Internet.Password())
                    };
                    string data = JsonConvert.SerializeObject(user);
                    StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("https://localhost:7007/api/users", content).Result;
                    if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync().Result.Equals("true"))
                    {
                        Console.WriteLine("Added user!");
                    }
                    else
                    {
                        Console.WriteLine("Error adding user!");
                    }
                }
            }
            
        }
    }
}
