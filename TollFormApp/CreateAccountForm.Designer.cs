
namespace TollFormApp
{
    partial class CreateAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountForm));
            this.accountCreationGroupBox = new System.Windows.Forms.GroupBox();
            this.backToLoginButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNamelabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.tROLLSDriverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._233N_Mostafavi_TeamsDataSet = new TollFormApp._233N_Mostafavi_TeamsDataSet();
            this.tROLLS_DriverTableAdapter = new TollFormApp._233N_Mostafavi_TeamsDataSetTableAdapters.TROLLS_DriverTableAdapter();
            this.accountCreationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tROLLSDriverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._233N_Mostafavi_TeamsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // accountCreationGroupBox
            // 
            this.accountCreationGroupBox.Controls.Add(this.backToLoginButton);
            this.accountCreationGroupBox.Controls.Add(this.loginButton);
            this.accountCreationGroupBox.Controls.Add(this.clearButton);
            this.accountCreationGroupBox.Controls.Add(this.passwordTextBox);
            this.accountCreationGroupBox.Controls.Add(this.firstNameTextBox);
            this.accountCreationGroupBox.Controls.Add(this.lastNameTextBox);
            this.accountCreationGroupBox.Controls.Add(this.emailTextBox);
            this.accountCreationGroupBox.Controls.Add(this.usernameTextBox);
            this.accountCreationGroupBox.Controls.Add(this.emailLabel);
            this.accountCreationGroupBox.Controls.Add(this.lastNamelabel);
            this.accountCreationGroupBox.Controls.Add(this.firstNameLabel);
            this.accountCreationGroupBox.Controls.Add(this.label2);
            this.accountCreationGroupBox.Controls.Add(this.usernameLabel);
            this.accountCreationGroupBox.Location = new System.Drawing.Point(175, 99);
            this.accountCreationGroupBox.Name = "accountCreationGroupBox";
            this.accountCreationGroupBox.Size = new System.Drawing.Size(397, 256);
            this.accountCreationGroupBox.TabIndex = 0;
            this.accountCreationGroupBox.TabStop = false;
            this.accountCreationGroupBox.Text = "Create an Account";
            // 
            // backToLoginButton
            // 
            this.backToLoginButton.Location = new System.Drawing.Point(288, 25);
            this.backToLoginButton.Name = "backToLoginButton";
            this.backToLoginButton.Size = new System.Drawing.Size(90, 23);
            this.backToLoginButton.TabIndex = 13;
            this.backToLoginButton.Text = "&Back to Login";
            this.backToLoginButton.UseVisualStyleBackColor = true;
            this.backToLoginButton.Click += new System.EventHandler(this.backToLoginButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(275, 200);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(103, 23);
            this.loginButton.TabIndex = 12;
            this.loginButton.Text = "Create &Account";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(19, 200);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(103, 23);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(123, 58);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(143, 20);
            this.passwordTextBox.TabIndex = 10;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(123, 92);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(143, 20);
            this.firstNameTextBox.TabIndex = 9;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(123, 123);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(143, 20);
            this.lastNameTextBox.TabIndex = 8;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(123, 153);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(143, 20);
            this.emailTextBox.TabIndex = 7;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(123, 27);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(143, 20);
            this.usernameTextBox.TabIndex = 6;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(71, 156);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "Email";
            // 
            // lastNamelabel
            // 
            this.lastNamelabel.AutoSize = true;
            this.lastNamelabel.Location = new System.Drawing.Point(45, 126);
            this.lastNamelabel.Name = "lastNamelabel";
            this.lastNamelabel.Size = new System.Drawing.Size(58, 13);
            this.lastNamelabel.TabIndex = 3;
            this.lastNamelabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(46, 95);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.firstNameLabel.TabIndex = 2;
            this.firstNameLabel.Text = "First Name";
            this.firstNameLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(48, 27);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // tROLLSDriverBindingSource
            // 
            this.tROLLSDriverBindingSource.DataMember = "TROLLS_Driver";
            this.tROLLSDriverBindingSource.DataSource = this._233N_Mostafavi_TeamsDataSet;
            // 
            // _233N_Mostafavi_TeamsDataSet
            // 
            this._233N_Mostafavi_TeamsDataSet.DataSetName = "_233N_Mostafavi_TeamsDataSet";
            this._233N_Mostafavi_TeamsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tROLLS_DriverTableAdapter
            // 
            this.tROLLS_DriverTableAdapter.ClearBeforeFill = true;
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.accountCreationGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateAccountForm";
            this.Text = "CreateAccountForm";
            this.Load += new System.EventHandler(this.CreateAccountForm_Load);
            this.accountCreationGroupBox.ResumeLayout(false);
            this.accountCreationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tROLLSDriverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._233N_Mostafavi_TeamsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox accountCreationGroupBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label lastNamelabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button backToLoginButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button clearButton;
        private _233N_Mostafavi_TeamsDataSet _233N_Mostafavi_TeamsDataSet;
        private System.Windows.Forms.BindingSource tROLLSDriverBindingSource;
        private _233N_Mostafavi_TeamsDataSetTableAdapters.TROLLS_DriverTableAdapter tROLLS_DriverTableAdapter;
    }
}