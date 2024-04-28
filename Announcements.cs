using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class Announcements : Form
    {
        private int societyId = SocietyDetails.societyId;

        public Announcements()
        {
            InitializeComponent();
            DisplayAnnouncements();
        }
        private void Announcements_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string announcementTitle = textBox1.Text;
            string announcementContent = richTextBox1.Text;
            DateTime announcementDate = DateTime.Now;

            if (string.IsNullOrEmpty(announcementTitle) || string.IsNullOrEmpty(announcementContent))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
            if (InsertAnnouncement(announcementTitle, announcementContent, announcementDate))
            {
                MessageBox.Show("Announcement added successfully.");
               
                textBox1.Text = "";
                richTextBox1.Text = "";
                DisplayAnnouncements();
            }
            else
            {
                MessageBox.Show("Failed to add announcement.");
            }
        }

        private bool InsertAnnouncement(string title, string content, DateTime date)
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                
                string query = "INSERT INTO announcements (society_id, title, content, announcement_date) VALUES (@societyId, @title, @content, @date)";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@societyId", societyId);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@date", date);

                int rowsAffected = dbHandler.ExecuteNonQuery(command);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to insert announcement.");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void DisplayAnnouncements()
        {
            DataTable announcementsTable = GetAnnouncementsDataFromDatabase();
            int top = 10;
            tableLayoutPanel1.Controls.Clear();
            foreach (DataRow row in announcementsTable.Rows)
            {
                string announcementTitle = row["title"].ToString();
                string announcementContent = row["content"].ToString();
                DateTime announcementDate = Convert.ToDateTime(row["announcement_date"]);

                Panel announcementPanel = new Panel();
                announcementPanel.BorderStyle = BorderStyle.FixedSingle;
                announcementPanel.Width = tableLayoutPanel1.Width - 10;
                announcementPanel.Padding = new Padding(10);

                Label titleLabel = new Label();
                titleLabel.Text = $"Title: {announcementTitle}";
                titleLabel.AutoSize = true;
                titleLabel.Location = new System.Drawing.Point(10, 10);
                announcementPanel.Controls.Add(titleLabel);

                Label contentLabel = new Label();
                contentLabel.Text = $"Content: {announcementContent}";
                contentLabel.AutoSize = true;
                contentLabel.Location = new System.Drawing.Point(10, 30);
                announcementPanel.Controls.Add(contentLabel);

                Label dateLabel = new Label();
                dateLabel.Text = $"Date: {announcementDate.ToString("MM/dd/yyyy HH:mm:ss")}";
                dateLabel.AutoSize = true;
                dateLabel.Location = new System.Drawing.Point(10, 50);
                announcementPanel.Controls.Add(dateLabel);

                announcementPanel.Location = new System.Drawing.Point(5, top);
                tableLayoutPanel1.Controls.Add(announcementPanel);

                top += announcementPanel.Height + 10;
            }
        }
        public DataTable GetAnnouncementsDataFromDatabase()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM announcements WHERE society_id = @societyId";
            command.Parameters.AddWithValue("@societyId", societyId);

            return dbHandler.ExecuteQuery(command);
        }

        private void logo0jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocietyDetails societyDetails = new SocietyDetails(societyId);
            societyDetails.Show();
            this.Hide();
        }
    }
}

