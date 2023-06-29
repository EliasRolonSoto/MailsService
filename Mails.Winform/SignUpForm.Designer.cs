namespace Mails.Winform
{
    partial class SignUpForm
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
            lblSignUp = new Label();
            txtEmail = new TextBox();
            btnSignUp = new Button();
            txtPassword = new TextBox();
            txtName = new TextBox();
            lblName = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblSignUp.Location = new Point(180, 50);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(123, 45);
            lblSignUp.TabIndex = 0;
            lblSignUp.Text = "SignUp";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(154, 234);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(168, 23);
            txtEmail.TabIndex = 1;
            txtEmail.Text = "example@example.com";
            // 
            // btnSignUp
            // 
            btnSignUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSignUp.Location = new Point(178, 387);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(125, 53);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "SignUp";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 309);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(168, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Location = new Point(154, 167);
            txtName.Name = "txtName";
            txtName.Size = new Size(168, 23);
            txtName.TabIndex = 4;
            txtName.Text = "example";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(153, 149);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 5;
            lblName.Text = "Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(153, 216);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(153, 291);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 573);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(txtPassword);
            Controls.Add(btnSignUp);
            Controls.Add(txtEmail);
            Controls.Add(lblSignUp);
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSignUp;
        private TextBox txtEmail;
        private Button btnSignUp;
        private TextBox txtPassword;
        private TextBox txtName;
        private Label lblName;
        private Label lblEmail;
        private Label lblPassword;
    }
}