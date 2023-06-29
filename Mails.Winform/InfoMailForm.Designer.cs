namespace Mails.Winform
{
    partial class InfoMailForm
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
            lblInfo = new Label();
            lblBody = new Label();
            lblSubject = new Label();
            txtBody = new TextBox();
            txtSubject = new TextBox();
            lblTo = new Label();
            txtTo = new TextBox();
            btnClose = new Button();
            lblFrom = new Label();
            txtFrom = new TextBox();
            btnReply = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.Location = new Point(277, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(56, 32);
            lblInfo.TabIndex = 14;
            lblInfo.Text = "Info";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBody.Location = new Point(56, 208);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(48, 21);
            lblBody.TabIndex = 13;
            lblBody.Text = "Body:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubject.Location = new Point(56, 158);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(64, 21);
            lblSubject.TabIndex = 12;
            lblSubject.Text = "Subject:";
            // 
            // txtBody
            // 
            txtBody.Location = new Point(56, 234);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(431, 242);
            txtBody.TabIndex = 11;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(56, 182);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(231, 23);
            txtSubject.TabIndex = 10;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTo.Location = new Point(56, 108);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(28, 21);
            lblTo.TabIndex = 9;
            lblTo.Text = "To:";
            // 
            // txtTo
            // 
            txtTo.Location = new Point(56, 132);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(231, 23);
            txtTo.TabIndex = 8;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.Location = new Point(307, 497);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 40);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFrom.Location = new Point(56, 58);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(50, 21);
            lblFrom.TabIndex = 16;
            lblFrom.Text = "From:";
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(56, 82);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(231, 23);
            txtFrom.TabIndex = 17;
            // 
            // btnReply
            // 
            btnReply.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReply.Location = new Point(151, 497);
            btnReply.Name = "btnReply";
            btnReply.Size = new Size(136, 40);
            btnReply.TabIndex = 18;
            btnReply.Text = "Reply";
            btnReply.UseVisualStyleBackColor = true;
            // 
            // InfoMailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 562);
            Controls.Add(btnReply);
            Controls.Add(txtFrom);
            Controls.Add(lblFrom);
            Controls.Add(btnClose);
            Controls.Add(lblInfo);
            Controls.Add(lblBody);
            Controls.Add(lblSubject);
            Controls.Add(txtBody);
            Controls.Add(txtSubject);
            Controls.Add(lblTo);
            Controls.Add(txtTo);
            Name = "InfoMailForm";
            Text = "InfoMailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label lblBody;
        private Label lblSubject;
        private TextBox txtBody;
        private TextBox txtSubject;
        private Label lblTo;
        private TextBox txtTo;
        private Button btnClose;
        private Label lblFrom;
        private TextBox txtFrom;
        private Button btnReply;
    }
}