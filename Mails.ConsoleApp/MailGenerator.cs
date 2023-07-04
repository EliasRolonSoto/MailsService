using Bogus;
using Mails.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Mails.ConsoleApp
{
    public class MailGenerator
    {
        public static void Generate(int amount)
        {
            
            var faker = new Faker();
            
            using (var client = new HttpClient())
            {
                var random = new Random();
                HttpResponseMessage response = client.GetAsync("https://localhost:7007/api/users").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                List<User> users = JsonConvert.DeserializeObject<List<User>>(data);
                for (int i = 0; i < amount; i++)
                {
                    var senderIndex = random.Next(0, users.Count);
                    var recipientIndex = random.Next(0, users.Count);
                    while (senderIndex == recipientIndex)
                    {
                        recipientIndex = random.Next(0, users.Count);
                    }
                    var mail = new Mail()
                    {
                        SenderEmail = users[senderIndex].Email,
                        Receiver = users[recipientIndex].Email,
                        Subject = faker.Lorem.Sentence(),
                        Body = faker.Lorem.Paragraph(),
                        Date = faker.Date.Past(10)
                    };
                    data = JsonConvert.SerializeObject(mail);
                    StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    response = client.PostAsync("https://localhost:7007/api/mails", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Added mail!");
                    }
                    else
                    {
                        Console.WriteLine("Error adding mail!");
                    }
                }
            }
        }
    }
}
