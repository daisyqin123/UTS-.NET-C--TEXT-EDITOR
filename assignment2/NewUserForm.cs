using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2
{
    public partial class NewUserForm : Form
    {
        LogInScreen logInScreen;

        public NewUserForm(LogInScreen logInScreen)
        {
            InitializeComponent();
            this.logInScreen = logInScreen; 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsernameExists(textBoxUserName.Text))
            {
                MessageBox.Show("Username already exists.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (textBoxFirstName.Text == "" || textBoxLastName.Text == ""|| textBoxUserName.Text == "" || textBoxPassword.Text == "" )
            {
                MessageBox.Show("Enter cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select user type.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else 
            { 

            File.AppendAllText("login.txt", $"\n{textBoxUserName.Text},{textBoxPassword.Text}," +
                    $"{comboBox1.SelectedItem},{textBoxFirstName.Text},{textBoxLastName.Text}," +
                    $"{dateTimePicker1.Text}");
            MessageBox.Show("Account created successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            logInScreen.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            logInScreen.Show();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool UsernameExists(string username)
        {
            string[] users = File.ReadAllLines("login.txt");
            foreach (string user in users)
            {
                string[] separator = { ",", " " };
                string[] userInfo = user.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (username == userInfo[0])
                    return true;
            }
            return false;
        }
    }
}
