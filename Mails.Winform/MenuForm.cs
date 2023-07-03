using Mails.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private Mail _mailInfo;
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
            _mailInfo = new Mail();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            dgvMails.ReadOnly = true;
            cbItemsPerPage.SelectedIndex = 1;
            txtPage.Text = "1";
            dgvMails.RowHeadersVisible = false;
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
            string mailData = "";
            Search search = new Search()
            {
                PageIndex = _currentPage,
                PageSize = _currentItemsPerPage,
                TextToSearch = textToSearch,
            };

            string json = JsonConvert.SerializeObject(search);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            if (data == EmailData.Inbox)
            {
                mailData = "inbox";
            }
            else if (data == EmailData.OutBox)
            {
                mailData = "outbox";
            }

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/mails/{mailData}/{_email}", content).Result;
            var jsonToDeserialize = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Response<Mail>>(jsonToDeserialize);
            dgvMails.DataSource = result.Items;

            //var total = result.Total;
            //lblResult.Text = $"{search.ResultMessage()}, from {total} mails";
            
        }
        private void cbItemsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {

            _currentItemsPerPage = int.Parse(cbItemsPerPage.SelectedItem.ToString()!);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                txtPage.Text = _currentPage.ToString();
                DataGridLoadChecker(_textToSearch);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage++;
            txtPage.Text = _currentPage.ToString();
            DataGridLoadChecker(_textToSearch);
        }

        private void btnInBox_Click(object sender, EventArgs e)
        {
            lblBox.Text = "InBox";
            DataGridLoadChecker(_textToSearch);
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            lblBox.Text = "OutBox";
            DataGridLoadChecker(_textToSearch);
        }

        private void btnNewMail_Click(object sender, EventArgs e)
        {
            NewMailForm form = new NewMailForm(_email);
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _textToSearch = txtSearch.Text;
            DataGridLoadChecker(_textToSearch);
        }

        private void dgvMails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho doble clic en una fila, no en el encabezado
            {
                DataGridViewRow row = dgvMails.Rows[e.RowIndex];
                _mailInfo.SenderEmail = row.Cells[1].Value.ToString();
                _mailInfo.Subject = row.Cells[2].Value.ToString();
                _mailInfo.Body = row.Cells[3].Value.ToString();
                _mailInfo.Receiver = row.Cells[4].Value.ToString();

                InfoMailForm infoMail = new InfoMailForm(_mailInfo, _email);
                infoMail.ShowDialog();
            }
        }
    }
}
