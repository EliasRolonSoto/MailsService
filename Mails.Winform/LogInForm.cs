using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Mails.Entities;
using Newtonsoft.Json;

namespace Mails.Winform
{
    public partial class LogInForm : Form
    {
        private readonly Uri _baseAddress = new Uri("https://localhost:7004/api");
        private readonly HttpClient _client;
        public LogInForm()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                var passwordHasher = new PasswordHasher<string>();
                string hashedPassword = passwordHasher.HashPassword(null!, txtPassword.Text);

                var loginRequest = new LogInRequest()
                {
                    Email = txtEmail.Text,
                    PasswordHash = hashedPassword
                };

                string data = JsonConvert.SerializeObject(loginRequest);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync($"{_client.BaseAddress}/users/login", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    MenuForm form = new MenuForm(txtEmail.Text);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Email and Password don't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}