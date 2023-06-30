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
    public partial class MenuForm : Form
    {
        private int _currentItemsPerPage;
        private int _currentPage;
        private readonly Uri _baseAddress = new Uri("https://localhost:7007/api");
        private readonly HttpClient _client;
        private readonly string _email;
        private string _textToSearch;
        enum EmailData
        {
            OutBox,
            Inbox
        }
        public MenuForm(string email)
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
            _email = email;
            _textToSearch = "";
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            cbItemsPerPage.SelectedIndex = 1;
            txtPage.Text = "1";

            var loginRequest = new Search()
            {
                TextToSearch = _email,
                PageIndex = int.Parse(txtPage.Text),

            };

            string data = JsonConvert.SerializeObject(loginRequest);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync($"{_client.BaseAddress}/users/login", content).Result;
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {

            int index;

            if (int.TryParse(txtPage.Text, out index))
            {
                _currentPage = index;
            }
            else
            {
                _currentPage = 1;
            }

            DataGridLoadChecker(_textToSearch);
        }
        private void DataGridLoadChecker(string textToSearch)
        {
            if (lblBox.Text == "OutBox")
            {
                LoadDataGrid(EmailData.OutBox, textToSearch);
            }
            else if (lblBox.Text == "InBox")
            {
                LoadDataGrid(EmailData.Inbox, textToSearch);
            }
        }
        private void LoadDataGrid(EmailData data, string textToSearch)
        {
            string mailData;
            Search search = new Search()
            {
                PageIndex = _currentPage,
                PageSize = _currentItemsPerPage,
                TextToSearch = textToSearch,
            };

            string json = JsonConvert.SerializeObject(search);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            if(data == EmailData.Inbox)
            {
                mailData = "inbox";
            }
            else if (data == EmailData.OutBox)
            {
                mailData = "outbox";
            }

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/emails/{_email}", content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
        }

        private void cbItemsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {

            _currentItemsPerPage = int.Parse(cbItemsPerPage.SelectedItem.ToString()!);
        }
    }
}
