using Mails.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mails.Winform
{
    public partial class SignUpForm : Form
    {
        private readonly Uri _baseAddress = new Uri("https://localhost:7004/api");
        private readonly HttpClient _client;
        public SignUpForm()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp();
        }
        private void SignUp()
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtName.Text))
            {
                var passwordHasher = new PasswordHasher<User>();
               

                var user = new User()
                {
                    Email = txtEmail.Text,
                    Name = txtName.Text,
                };
                string hashedPassword = passwordHasher.HashPassword(user, txtPassword.Text);
                user.PasswordHash = hashedPassword;
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync($"{_client.BaseAddress}/users", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The email is already in use", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
