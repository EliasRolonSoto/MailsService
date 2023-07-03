using Mails.Entities;
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
    public partial class NewMailForm : Form
    {
        private readonly Uri _baseAddress = new Uri("https://localhost:7007/api");
        private readonly HttpClient _client;
        private readonly string _email;
        private readonly string _to;
        public NewMailForm(string email)
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
            _email = email;
            _to = string.Empty;
        }
        public NewMailForm(string email, string to)
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
            _email = email;
            _to = to;
        }
        

        private void NewMailForm_Load(object sender, EventArgs e)
        {
            txtTo.Text = _to;
        }
        private void SendMail()
        {
            if (!string.IsNullOrEmpty(txtTo.Text))
            {
                var mail = new Mail()
                {
                    Subject = txtSubject.Text,
                    Body = txtBody.Text,
                    SenderEmail = _email,
                    Receiver = txtTo.Text,
                    Date = DateTime.Now,
                };
                var jsonMail = JsonConvert.SerializeObject(mail);
                StringContent content = new StringContent(jsonMail, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/mails", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Mail successfully sent!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't send mail");
                }
            }
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMail();

        }
    }
}
