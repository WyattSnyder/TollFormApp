using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TollFormApp
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=cisdbss.pcc.edu;" +
                                   "Initial Catalog=233N_Mostafavi_Teams;" +
                                   "Persist Security Info=True;" +
                                   "User ID=233N_Mostafavi_Teams;" +
                                    "Password=ILoveCSharp@2";
            //connecting to database   
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //sql duplicate inputs search
            SqlCommand duplicateEmail = new SqlCommand("SELECT Convert(varchar(20),email_id) FROM TROLLS_Driver WHERE Convert(varchar(20),email_id) ='" + emailTextBox.Text + "'", conn);
            string email_id = (string)duplicateEmail.ExecuteScalar();

            //the following will validate the input for non duplicate emails
            string myEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            //validate all fields have been filled
            if (firstNameTextBox.Text == "" | lastNameTextBox.Text == "" | usernameTextBox.Text == "" | passwordTextBox.Text == "")
            {
                MessageBox.Show("One or more fields are blank");
            }
            else
            {
                if (email_id == emailTextBox.Text)
            {
                conn.Close();
                MessageBox.Show("Email already has an account");
            }
            else
            {
                    if (Regex.IsMatch(emailTextBox.Text, myEmail))
                    {

                        //assigning textbox to a string variable called
                        string pass = passwordTextBox.Text;
                        string hash = string.Empty;
                        //creating sha512 hash
                        using (SHA512 sha512Hash = SHA512.Create())
                        {

                            byte[] sourceBytes = Encoding.UTF8.GetBytes(pass);
                            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                            hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                            // account creation successful
                            MessageBox.Show("Account Created go Back to Login");
                        }
                        try
                        {

                            string FirstName = firstNameTextBox.Text;
                            string LastName = lastNameTextBox.Text;
                            string Email = emailTextBox.Text;
                            string Username = usernameTextBox.Text;


                            // insert string values into sql table
                            string query = "INSERT INTO TROLLS_Driver (username, password, last_name, first_name, email_id)";
                            query += " VALUES (@Username, @Password, @LastName, @FirstName, @Email)";
                            SqlCommand Command = new SqlCommand(query, conn);
                            Command.Parameters.AddWithValue("@Username", Username);
                            Command.Parameters.AddWithValue("@Password", hash);
                            Command.Parameters.AddWithValue("@LastName", LastName);
                            Command.Parameters.AddWithValue("@FirstName", FirstName);
                            Command.Parameters.AddWithValue("@Email", Email);
                            Command.ExecuteNonQuery();


                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not a valid email");
                        return;
                    }
                    return;
                }
                return;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clear textboxes
            usernameTextBox.Text = null;
            passwordTextBox.Text = null;
            firstNameTextBox.Text = null;
            lastNameTextBox.Text = null;
            emailTextBox.Text = null;
        }

        private void backToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Close();
            loginForm.Show();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_233N_Mostafavi_TeamsDataSet.TROLLS_Driver' table. You can move, or remove it, as needed.
            //this.tROLLS_DriverTableAdapter.Fill(this._233N_Mostafavi_TeamsDataSet.TROLLS_Driver);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
