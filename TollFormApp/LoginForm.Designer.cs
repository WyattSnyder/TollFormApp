
namespace TollFormApp
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
      this.components = new System.ComponentModel.Container();
      this.loginGroupBox = new System.Windows.Forms.GroupBox();
      this.cancelButton = new System.Windows.Forms.Button();
      this.newUserButton = new System.Windows.Forms.Button();
      this.LoginButton = new System.Windows.Forms.Button();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.emailTextBox = new System.Windows.Forms.TextBox();
      this.passwordLabel = new System.Windows.Forms.Label();
      this.emailLabel = new System.Windows.Forms.Label();
      this.loginTitleLabel = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.loginGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // loginGroupBox
      // 
      this.loginGroupBox.Controls.Add(this.cancelButton);
      this.loginGroupBox.Controls.Add(this.newUserButton);
      this.loginGroupBox.Controls.Add(this.LoginButton);
      this.loginGroupBox.Controls.Add(this.passwordTextBox);
      this.loginGroupBox.Controls.Add(this.emailTextBox);
      this.loginGroupBox.Controls.Add(this.passwordLabel);
      this.loginGroupBox.Controls.Add(this.emailLabel);
      this.loginGroupBox.Location = new System.Drawing.Point(12, 60);
      this.loginGroupBox.Name = "loginGroupBox";
      this.loginGroupBox.Size = new System.Drawing.Size(576, 294);
      this.loginGroupBox.TabIndex = 0;
      this.loginGroupBox.TabStop = false;
      this.loginGroupBox.Text = "Login";
      // 
      // cancelButton
      // 
      this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancelButton.Location = new System.Drawing.Point(338, 234);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(104, 31);
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Clear";
      this.toolTip1.SetToolTip(this.cancelButton, "Clear input fields");
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // newUserButton
      // 
      this.newUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.newUserButton.Location = new System.Drawing.Point(228, 234);
      this.newUserButton.Name = "newUserButton";
      this.newUserButton.Size = new System.Drawing.Size(104, 31);
      this.newUserButton.TabIndex = 5;
      this.newUserButton.Text = "New User";
      this.toolTip1.SetToolTip(this.newUserButton, "Create a new user account");
      this.newUserButton.UseVisualStyleBackColor = true;
      this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
      // 
      // LoginButton
      // 
      this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LoginButton.Location = new System.Drawing.Point(118, 234);
      this.LoginButton.Name = "LoginButton";
      this.LoginButton.Size = new System.Drawing.Size(104, 31);
      this.LoginButton.TabIndex = 4;
      this.LoginButton.Text = "Login";
      this.toolTip1.SetToolTip(this.LoginButton, "Logs into the main program");
      this.LoginButton.UseVisualStyleBackColor = true;
      this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(242, 98);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(164, 20);
      this.passwordTextBox.TabIndex = 3;
      // 
      // emailTextBox
      // 
      this.emailTextBox.Location = new System.Drawing.Point(242, 55);
      this.emailTextBox.Name = "emailTextBox";
      this.emailTextBox.Size = new System.Drawing.Size(164, 20);
      this.emailTextBox.TabIndex = 2;
      // 
      // passwordLabel
      // 
      this.passwordLabel.AutoSize = true;
      this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.passwordLabel.Location = new System.Drawing.Point(137, 98);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(75, 18);
      this.passwordLabel.TabIndex = 1;
      this.passwordLabel.Text = "Password";
      // 
      // emailLabel
      // 
      this.emailLabel.AutoSize = true;
      this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.emailLabel.Location = new System.Drawing.Point(137, 57);
      this.emailLabel.Name = "emailLabel";
      this.emailLabel.Size = new System.Drawing.Size(45, 18);
      this.emailLabel.TabIndex = 0;
      this.emailLabel.Text = "Email";
      // 
      // loginTitleLabel
      // 
      this.loginTitleLabel.AutoSize = true;
      this.loginTitleLabel.Font = new System.Drawing.Font("MS Outlook", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.loginTitleLabel.Location = new System.Drawing.Point(192, 9);
      this.loginTitleLabel.Name = "loginTitleLabel";
      this.loginTitleLabel.Size = new System.Drawing.Size(205, 32);
      this.loginTitleLabel.TabIndex = 1;
      this.loginTitleLabel.Text = "Toll Information ";
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 366);
      this.Controls.Add(this.loginTitleLabel);
      this.Controls.Add(this.loginGroupBox);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "LoginForm";
      this.Text = "Login";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
      this.Load += new System.EventHandler(this.LoginForm_Load);
      this.loginGroupBox.ResumeLayout(false);
      this.loginGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.GroupBox loginGroupBox;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.Label emailLabel;
    private System.Windows.Forms.Label loginTitleLabel;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button newUserButton;
    private System.Windows.Forms.Button LoginButton;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.TextBox emailTextBox;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}

