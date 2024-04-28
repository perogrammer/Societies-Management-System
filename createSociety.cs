using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class createSociety : Form
    {
        public static int userID;
        public createSociety()
        {
            InitializeComponent();
        }

        private void createSociety_Load(object sender, EventArgs e)
        {
            userID = Login.userId;
            if (userID < 0)
            {
                MessageBox.Show("Login to continue!");
                Login LoginPage = new Login();
                LoginPage.Show();
                this.Close();
            }
        }

        private void logo0jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Societies Societies = new Societies();
            Societies.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = richTextBox1.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                if (InsertSociety(name, description))
                {
                    MessageBox.Show("Society created successfully.");
                    
                    LandingPage landingPage = new LandingPage();
                    landingPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create society.");
                }
            }
            else
                MessageBox.Show("Please enter both name and description.");
        }
        private bool InsertSociety(string name, string description)
        {
            try
            {
                string query = "INSERT INTO societies (name, description, president_id) VALUES (@name, @description, @userID)";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@userID", userID);

                DatabaseHandler dbHandler = new DatabaseHandler();
                int rowsAffected = dbHandler.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
