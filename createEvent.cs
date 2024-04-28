using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class createEvent : Form
    {
        public static int userID;
        public createEvent()
        {
            InitializeComponent();
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {
            
            
            userID = Login.userId;
            if (userID != 1) //admin id
            {
                MessageBox.Show("This action requires admin privileges!");
                Login LoginPage = new Login();
                LoginPage.Show();
                this.Close();
            }
            PopulateSocieitesDropdown();
        }
        private void PopulateSocieitesDropdown()
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT name FROM societies"; 
                DataTable result = dbHandler.ExecuteQuery(command);
                foreach (DataRow row in result.Rows)
                {
                    string societyName = row["name"].ToString();
                    comboBox1.Items.Add(societyName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void logo0jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Events events = new Events();
            events.Show();
            this.Hide();
        }

        public int GetSocietyIDFromName(string societyName)
        {
            try
            {
                string query = "SELECT society_id FROM societies WHERE name = @societyName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@societyName", societyName);

                DatabaseHandler dbHandler = new DatabaseHandler();
                object result = dbHandler.ExecuteQueryScalar(command);

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving society ID: " + ex.Message);
            }
            return -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string societyName = comboBox1.SelectedItem?.ToString();
            int societyID = GetSocietyIDFromName(societyName);
            if (societyID < 0)
            {
                MessageBox.Show("No Society Exists with that name");
                return;
            }
            string description = richTextBox1.Text;
            DateTime date = dateTimePicker1.Value.Date;
            string location = textBox3.Text;


            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(societyName) && !string.IsNullOrEmpty(location))
            {
                if (InsertEvent(name, societyID, description, date, location))
                {
                    MessageBox.Show("Event created successfully.");

                    LandingPage landingPage = new LandingPage();
                    landingPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create event.");
                }
            }
            else
                MessageBox.Show("Please fill in all fields");
        }

        private bool InsertEvent(string name, int societyID, string description, DateTime date, string location)
        {
            try
            {
                string query = "INSERT INTO events (society_id, name, description, event_date, location) VALUES (@societyId, @name, @description, @eventDate, @location)";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@societyId", societyID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@eventDate", date);
                command.Parameters.AddWithValue("@location", location);

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
