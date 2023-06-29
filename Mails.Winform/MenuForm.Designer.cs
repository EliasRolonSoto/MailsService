namespace Mails.Winform
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInBox = new Button();
            lblInbox = new Label();
            dgvMails = new DataGridView();
            lblMenu = new Label();
            btnSent = new Button();
            btnNewMail = new Button();
            lblResult = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            txtPage = new TextBox();
            cbItemsPerPage = new ComboBox();
            btnNext = new Button();
            btnPrevious = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMails).BeginInit();
            SuspendLayout();
            // 
            // btnInBox
            // 
            btnInBox.Location = new Point(23, 149);
            btnInBox.Name = "btnInBox";
            btnInBox.Size = new Size(143, 39);
            btnInBox.TabIndex = 0;
            btnInBox.Text = "InBox";
            btnInBox.UseVisualStyleBackColor = true;
            // 
            // lblInbox
            // 
            lblInbox.AutoSize = true;
            lblInbox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblInbox.Location = new Point(23, 18);
            lblInbox.Name = "lblInbox";
            lblInbox.Size = new Size(73, 32);
            lblInbox.TabIndex = 1;
            lblInbox.Text = "InBox";
            // 
            // dgvMails
            // 
            dgvMails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMails.Location = new Point(207, 149);
            dgvMails.Name = "dgvMails";
            dgvMails.RowTemplate.Height = 25;
            dgvMails.Size = new Size(634, 412);
            dgvMails.TabIndex = 2;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Location = new Point(23, 121);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(38, 15);
            lblMenu.TabIndex = 4;
            lblMenu.Text = "Menu";
            // 
            // btnSent
            // 
            btnSent.Location = new Point(23, 194);
            btnSent.Name = "btnSent";
            btnSent.Size = new Size(143, 39);
            btnSent.TabIndex = 8;
            btnSent.Text = "Sent";
            btnSent.UseVisualStyleBackColor = true;
            // 
            // btnNewMail
            // 
            btnNewMail.Location = new Point(23, 239);
            btnNewMail.Name = "btnNewMail";
            btnNewMail.Size = new Size(143, 39);
            btnNewMail.TabIndex = 9;
            btnNewMail.Text = "New Mail";
            btnNewMail.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(207, 564);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 10;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(207, 102);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(212, 23);
            txtSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(446, 101);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 23);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtPage
            // 
            txtPage.Location = new Point(655, 564);
            txtPage.Name = "txtPage";
            txtPage.Size = new Size(56, 23);
            txtPage.TabIndex = 14;
            // 
            // cbItemsPerPage
            // 
            cbItemsPerPage.FormattingEnabled = true;
            cbItemsPerPage.Items.AddRange(new object[] { "5", "10", "15", "20", "25" });
            cbItemsPerPage.Location = new Point(802, 567);
            cbItemsPerPage.Name = "cbItemsPerPage";
            cbItemsPerPage.Size = new Size(39, 23);
            cbItemsPerPage.TabIndex = 15;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(717, 564);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(62, 26);
            btnNext.TabIndex = 17;
            btnNext.Text = "Next->";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(584, 564);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(65, 26);
            btnPrevious.TabIndex = 18;
            btnPrevious.Text = "<-Prev";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 657);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(cbItemsPerPage);
            Controls.Add(txtPage);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblResult);
            Controls.Add(btnNewMail);
            Controls.Add(btnSent);
            Controls.Add(lblMenu);
            Controls.Add(dgvMails);
            Controls.Add(lblInbox);
            Controls.Add(btnInBox);
            Name = "MenuForm";
            Text = "MenuForm";
            Load += MenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInBox;
        private Label lblInbox;
        private DataGridView dgvMails;
        private Label lblMenu;
        private Button btnSent;
        private Button btnNewMail;
        private Label lblResult;
        private TextBox txtSearch;
        private Button btnSearch;
        private TextBox txtPage;
        private ComboBox cbItemsPerPage;
        private Button btnNext;
        private Button btnPrevious;
    }
}