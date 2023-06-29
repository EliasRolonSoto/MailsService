namespace Mails.Winform
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogIn = new Button();
            lblLogIn = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            btnSignUp = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(142, 183);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 23);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "example@example.com";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(142, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(189, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogIn
            // 
            btnLogIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogIn.Location = new Point(175, 337);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(124, 42);
            btnLogIn.TabIndex = 2;
            btnLogIn.Text = "LogIn";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // lblLogIn
            // 
            lblLogIn.AutoSize = true;
            lblLogIn.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogIn.Location = new Point(186, 47);
            lblLogIn.Name = "lblLogIn";
            lblLogIn.Size = new Size(100, 45);
            lblLogIn.TabIndex = 3;
            lblLogIn.Text = "LogIn";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(142, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(142, 242);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // btnSignUp
            // 
            btnSignUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSignUp.Location = new Point(175, 405);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(124, 42);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "SignUp";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 580);
            Controls.Add(btnSignUp);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblLogIn);
            Controls.Add(btnLogIn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Name = "LogInForm";
            Text = "Form1";
            Load += LogInForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogIn;
        private Label lblLogIn;
        private Label lblEmail;
        private Label lblPassword;
        private Button btnSignUp;
    }
}