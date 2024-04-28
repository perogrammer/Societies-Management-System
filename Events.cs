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
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
        }

        private void logopngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Hide();
        }

        private void Events_Load(object sender, EventArgs e)
        {
            DisplayEventsDetails();
        }
        private void DisplayEventsDetails()
        {
            DataTable eventsTable = GetEventsDataFromDatabase();
            int top = 30;

            foreach (DataRow row in eventsTable.Rows)
            {
                string eventName = row["name"].ToString();
                string eventDescription = row["description"].ToString();
                string societyName = GetSocietyNameFromId(Convert.ToInt32(row["society_id"]));
                string location = row["location"].ToString();
                string eventDate = row["event_date"].ToString();
                DateTime dateTime = DateTime.Parse(eventDate);
                eventDate = dateTime.ToString("yyyy-MM-dd");

                Panel eventPanel = new Panel();
                eventPanel.BorderStyle = BorderStyle.FixedSingle;
                eventPanel.Width = tableLayoutPanel1.Width - 10;
                eventPanel.Padding = new Padding(10);

                Label nameLabel = new Label();
                nameLabel.Text = $"Event Name: {eventName}";
                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(10, 10);
                eventPanel.Controls.Add(nameLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $"Description: {eventDescription}";
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new Point(10, 30);
                eventPanel.Controls.Add(descriptionLabel);

                Label societyLabel = new Label();
                societyLabel.Text = $"Society: {societyName}";
                societyLabel.AutoSize = true;
                societyLabel.Location = new Point(10, 50);
                eventPanel.Controls.Add(societyLabel);

                Label dateLabel = new Label();
                dateLabel.Text = $"Date: {eventDate}";
                dateLabel.AutoSize = true;
                dateLabel.Location = new Point(10, 70);
                eventPanel.Controls.Add(dateLabel);

                Label locationLabel = new Label();
                locationLabel.Text = $"Location: {location}";
                locationLabel.AutoSize = true;
                locationLabel.Location = new Point(10, 90);
                eventPanel.Controls.Add(locationLabel);

                eventPanel.Location = new Point(20, top);
                tableLayoutPanel1.Controls.Add(eventPanel);

                eventPanel.Height += 10;
                top += eventPanel.Height + 10; 
            }
        }


        private string GetSocietyNameFromId(int societyID)
        {
            try
            {
                string query = "SELECT name FROM societies WHERE society_id = @societyId";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@societyId", societyID);

                DatabaseHandler dbHandler = new DatabaseHandler();
                object result = dbHandler.ExecuteQueryScalar(command);

                return result != null ? result.ToString() : "Unknown";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private DataTable GetEventsDataFromDatabase()
        {
            try
            {
                string query = "SELECT * FROM events";
                SqlCommand command = new SqlCommand(query);
                DatabaseHandler dbHandler = new DatabaseHandler();
                return dbHandler.ExecuteQuery(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private void addNewEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createEvent createEventPage = new createEvent();
            createEventPage.Show();
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
