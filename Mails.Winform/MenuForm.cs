﻿using System;
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
        private readonly string _email;
        public MenuForm(string email)
        {
            InitializeComponent();
            _email = email;
        }




    }
}
