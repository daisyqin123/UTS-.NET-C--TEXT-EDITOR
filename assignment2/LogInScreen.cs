using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment2
{
    public partial class LogInScreen : Form
    {
        public LogInScreen()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
                textBox2.PasswordChar = '\u0000';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginSuccessful = false;
            string[] users = File.ReadAllLines("login.txt");
            //eachline-user, allline-users
            foreach( string user in users)
            {
                string[] separator = { ",", " " };
                //it removes empty entries(RemoveEmptyEntries)
                string[] userInfo = user.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (textBox1.Text == userInfo[0] && textBox2.Text == userInfo[1])
                {
                    loginSuccessful = true;
                    Hide();
                    //take three paramater 1.loginscreen 2.fullname 3. userType into TextEditorWindow
                    new TextEditorWindow(this, $"{userInfo[3]} {userInfo[4]}", userInfo[2]).Show();
                    break;
                }
            }
            if (!loginSuccessful)
            {
                MessageBox.Show("Unknown username or incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox2.Text = String.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new NewUserForm(this).Show();
        }
    }
}