using Mails.Entities;
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
    public partial class InfoMailForm : Form
    {
        private Mail _mail;
        private readonly string _email;
        public InfoMailForm(Mail mail, string email)
        {
            InitializeComponent();
            _mail = mail;
            _email = email;
        }
        

        private void InfoMailForm_Load(object sender, EventArgs e)
        {
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
            txtSubject.Enabled = false;
            txtBody.Enabled = false;
            txtFrom.Text = _mail.SenderEmail.ToString();
            txtTo.Text = _mail.Receiver.ToString();
            txtSubject.Text = _mail.Subject.ToString();
            txtBody.Text = _mail.Body.ToString();

        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            var to = txtFrom.Text;
            NewMailForm reply = new NewMailForm(_email, to);
            reply.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
