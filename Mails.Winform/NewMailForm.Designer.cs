namespace Mails.Winform
{
    partial class NewMailForm
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
            btnSend = new Button();
            txtTo = new TextBox();
            lblTo = new Label();
            txtSubject = new TextBox();
            txtBody = new TextBox();
            lblSubject = new Label();
            lblBody = new Label();
            lblNewMail = new Label();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSend.Location = new Point(456, 444);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(114, 42);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(89, 89);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(231, 23);
            txtTo.TabIndex = 1;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTo.Location = new Point(89, 65);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(28, 21);
            lblTo.TabIndex = 2;
            lblTo.Text = "To:";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(89, 142);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(231, 23);
            txtSubject.TabIndex = 3;
            // 
            // txtBody
            // 
            txtBody.Location = new Point(89, 196);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(431, 242);
            txtBody.TabIndex = 4;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubject.Location = new Point(89, 118);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(64, 21);
            lblSubject.TabIndex = 5;
            lblSubject.Text = "Subject:";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBody.Location = new Point(89, 172);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(48, 21);
            lblBody.TabIndex = 6;
            lblBody.Text = "Body:";
            // 
            // lblNewMail
            // 
            lblNewMail.AutoSize = true;
            lblNewMail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewMail.Location = new Point(246, 9);
            lblNewMail.Name = "lblNewMail";
            lblNewMail.Size = new Size(115, 32);
            lblNewMail.TabIndex = 7;
            lblNewMail.Text = "New Mail";
            // 
            // NewMailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 508);
            Controls.Add(lblNewMail);
            Controls.Add(lblBody);
            Controls.Add(lblSubject);
            Controls.Add(txtBody);
            Controls.Add(txtSubject);
            Controls.Add(lblTo);
            Controls.Add(txtTo);
            Controls.Add(btnSend);
            Name = "NewMailForm";
            Text = "NewMailForm";
            Load += NewMailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox txtTo;
        private Label lblTo;
        private TextBox txtSubject;
        private TextBox txtBody;
        private Label lblSubject;
        private Label lblBody;
        private Label lblNewMail;
    }
}