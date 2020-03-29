namespace SessionTracker
{
    partial class LoginDialog
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.usernameTextboxLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextboxLabel = new System.Windows.Forms.Label();
            this.loginFormLabel = new System.Windows.Forms.Label();
            this.campusComboBox = new System.Windows.Forms.ComboBox();
            this.campusComboBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.AccessibleDescription = "Login Button";
            this.loginBtn.Location = new System.Drawing.Point(11, 281);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 31);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.usernameTextbox.Location = new System.Drawing.Point(13, 72);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(200, 22);
            this.usernameTextbox.TabIndex = 0;
            // 
            // usernameTextboxLabel
            // 
            this.usernameTextboxLabel.AutoSize = true;
            this.usernameTextboxLabel.Location = new System.Drawing.Point(13, 52);
            this.usernameTextboxLabel.Name = "usernameTextboxLabel";
            this.usernameTextboxLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameTextboxLabel.TabIndex = 2;
            this.usernameTextboxLabel.Text = "Username";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(12, 147);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(201, 22);
            this.passwordTextbox.TabIndex = 1;
            // 
            // passwordTextboxLabel
            // 
            this.passwordTextboxLabel.AutoSize = true;
            this.passwordTextboxLabel.Location = new System.Drawing.Point(13, 127);
            this.passwordTextboxLabel.Name = "passwordTextboxLabel";
            this.passwordTextboxLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordTextboxLabel.TabIndex = 4;
            this.passwordTextboxLabel.Text = "Password";
            // 
            // loginFormLabel
            // 
            this.loginFormLabel.AutoSize = true;
            this.loginFormLabel.CausesValidation = false;
            this.loginFormLabel.Location = new System.Drawing.Point(9, 8);
            this.loginFormLabel.Name = "loginFormLabel";
            this.loginFormLabel.Size = new System.Drawing.Size(159, 17);
            this.loginFormLabel.TabIndex = 5;
            this.loginFormLabel.Text = "Please login to continue";
            // 
            // campusComboBox
            // 
            this.campusComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.campusComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.campusComboBox.FormattingEnabled = true;
            this.campusComboBox.Location = new System.Drawing.Point(11, 220);
            this.campusComboBox.Name = "campusComboBox";
            this.campusComboBox.Size = new System.Drawing.Size(202, 24);
            this.campusComboBox.TabIndex = 2;
            // 
            // campusComboBoxLabel
            // 
            this.campusComboBoxLabel.AutoSize = true;
            this.campusComboBoxLabel.Location = new System.Drawing.Point(13, 200);
            this.campusComboBoxLabel.Name = "campusComboBoxLabel";
            this.campusComboBoxLabel.Size = new System.Drawing.Size(59, 17);
            this.campusComboBoxLabel.TabIndex = 7;
            this.campusComboBoxLabel.Text = "Campus";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 324);
            this.Controls.Add(this.campusComboBoxLabel);
            this.Controls.Add(this.campusComboBox);
            this.Controls.Add(this.usernameTextboxLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.loginFormLabel);
            this.Controls.Add(this.passwordTextboxLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label usernameTextboxLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label passwordTextboxLabel;
        private System.Windows.Forms.Label loginFormLabel;
        private System.Windows.Forms.ComboBox campusComboBox;
        private System.Windows.Forms.Label campusComboBoxLabel;
    }
}

