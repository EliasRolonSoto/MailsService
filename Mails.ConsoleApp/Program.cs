using Mails.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Enter your email: ");
var email = Console.ReadLine();
Console.WriteLine("Enter your password: ");
var password = Console.ReadLine();

var loginRequest = new LogInRequest()
{
	Email = email,
	PasswordHash = password
};
using (var client = new HttpClient())
{
    string data = JsonConvert.SerializeObject(loginRequest);
    StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
    HttpResponseMessage response = client.PostAsync("https://localhost:7007/api/users/login", content).Result;
    if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync().Result.Equals("true"))
    {
        Console.WriteLine("Logged in successfully!");
        Console.WriteLine("---MENU---");
        Console.WriteLine("1 - INBOX\n2 - OUTBOX\n3 - LOGOUT");
        var key = int.Parse(Console.ReadLine());
        switch (key)
        {
            case 1:
                response = client.GetAsync("https://localhost:7007/api/mails/all/inbox/"+email).Result;
                data = response.Content.ReadAsStringAsync().Result;
                var resultList = JsonConvert.DeserializeObject<List<Mail>>(data);
                Console.WriteLine("---INBOX---");
                foreach (var item in resultList)
                {
                    Console.WriteLine("---Mail---");
                    Console.WriteLine(item);
                    Console.WriteLine("----------");
                }
                break;
            case 2:
                response = client.GetAsync("https://localhost:7007/api/mails/all/outbox/" + email).Result;
                data = response.Content.ReadAsStringAsync().Result;
                resultList = JsonConvert.DeserializeObject<List<Mail>>(data);
                Console.WriteLine("---OUTBOX---");
                foreach (var item in resultList)
                {
                    Console.WriteLine("---Mail---");
                    Console.WriteLine(item);
                    Console.WriteLine("----------");
                }
                break;
            case 3:
                break;
                //default:
        }
    }
    else
    {
        Console.WriteLine("Email or password don't match!");
    }
}



