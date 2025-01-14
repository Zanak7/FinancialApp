namespace FinancialApp
{
    partial class LoginForm
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
            nameTextBox = new TextBox();
            loginButton = new Button();
            label1 = new Label();
            signupButton = new Button();
            passwordTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(65, 169);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Enter your name";
            nameTextBox.Size = new Size(229, 23);
            nameTextBox.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FloralWhite;
            loginButton.Font = new Font("Segoe UI", 11F);
            loginButton.Location = new Point(65, 269);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(229, 66);
            loginButton.TabIndex = 1;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(70, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 54);
            label1.TabIndex = 2;
            label1.Text = "WELCOME";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signupButton
            // 
            signupButton.BackColor = Color.FloralWhite;
            signupButton.Font = new Font("Segoe UI", 11F);
            signupButton.Location = new Point(65, 341);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(229, 66);
            signupButton.TabIndex = 3;
            signupButton.Text = "Register";
            signupButton.UseVisualStyleBackColor = false;
            signupButton.Click += signupButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(65, 225);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.PlaceholderText = "Enter your password";
            passwordTextBox.Size = new Size(229, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(65, 85);
            label2.Name = "label2";
            label2.Size = new Size(213, 42);
            label2.TabIndex = 5;
            label2.Text = "Please Log in to your account\r\nor Create new.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 151);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Name *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 207);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 7;
            label4.Text = "Password *";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(375, 458);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordTextBox);
            Controls.Add(signupButton);
            Controls.Add(label1);
            Controls.Add(loginButton);
            Controls.Add(nameTextBox);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Button loginButton;
        private Label label1;
        private Button signupButton;
        private TextBox passwordTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}