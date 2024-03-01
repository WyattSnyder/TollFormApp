/*
 * Jose Alvareztorre
 * 233N
 * 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollFormApp.Properties;
using System.Security.Cryptography;

namespace TollFormApp
{
  public partial class LoginForm : Form
  {

    public LoginForm()
    {
      InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
      //load form features 
      this.Icon = Resources.loginIcon;
      passwordTextBox.PasswordChar = '*';

    }

    //login button processes
    private void LoginButton_Click(object sender, EventArgs e)
    {
      string email = emailTextBox.Text;
      string password = passwordTextBox.Text;
      string testString = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
      string hashedPassword = string.Empty;

      //validate email here
      if (Regex.IsMatch(email, testString))
      {

        //password is hashed here
        using (SHA512 sha512Hash = SHA512.Create())
        {

          byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
          byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
          hashedPassword = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
        }

        //connecting to database
        string connString = "Data Source=cisdbss.pcc.edu;" +
                            "Initial Catalog=233N_Mostafavi_Teams;" +
                            "Persist Security Info=True;" +
                            "User ID=233N_Mostafavi_Teams;" +
                             "Password=ILoveCSharp@2";
        SqlConnection conn = new SqlConnection(connString);

        try
        {
          //open connection to database, send SQL statement and then close connection
          conn.Open();
          SqlCommand statement = new SqlCommand("SELECT driver_id " +
                                                "FROM TROLLS_Driver " +
                                                "WHERE email_id=@EmailId " +
                                                "AND password=@Password ", conn);

          //this prevents sql injection
          statement.Parameters.AddWithValue("@EmailId", email);
          statement.Parameters.AddWithValue("@Password", hashedPassword);

          //reader reads the returned query, if there is a row that means the user and hashed password match
          SqlDataReader reader = statement.ExecuteReader();
          if (reader.HasRows)
          {

            //getting driverID to send to input form
            int driverID = 0;
            while (reader.Read())
            {
              driverID = reader.GetInt32(0);
            }
            

            //close the reader object once we're done reading the records
            reader.Close();

            //switch to input form since the user entered valid credentials
            InputForm inputForm = new InputForm(driverID);
            this.Hide();
            inputForm.Show();
          }
          else //invalid credentials must've been put in if no records were found
          {
            reader.Close();
            MessageBox.Show("Please enter valid login credentials", "Invalid Login", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Something must've gone really wrong for this message to pop up...");
        }
        finally //close the connection to the database once done
        {
          conn.Close();
        }

      } else
      {
        MessageBox.Show("Please enter valid login credentials", "Invalid Login", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    //this should open the CreateAccount form
    private void newUserButton_Click(object sender, EventArgs e)
    {
      CreateAccountForm createAccountForm = new CreateAccountForm();
      this.Hide();
      createAccountForm.Show();

    }

    //deletes email/password textbox content 
    private void cancelButton_Click(object sender, EventArgs e)
    {
      emailTextBox.Text = string.Empty;
      passwordTextBox.Text = string.Empty;

    }

    //when the form is about to close, it asks the user if they want to continue
    private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      //check the close reason before bringin the pop up to confirm the event was sent by the user and not programatically
      if (e.CloseReason == CloseReason.UserClosing) 
      {
        DialogResult result = MessageBox.Show("Are you sure you want to exit this program?", "Exiting", 
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
        {
          e.Cancel = true;
        } 
        else
        {
          Application.Exit();

        }
      }
    }
  }
}
