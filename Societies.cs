using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class Societies : Form
    {
        public static int userID;
        string connectionString = "Data Source=DESKTOP-CD9SUPU\\SQLEXPRESS;Initial Catalog=society;Integrated Security=True;";

        public Societies()
        {
            InitializeComponent();
        }

        private void Societies_Load(object sender, EventArgs e)
        {
            DisplaySocietiesDetails();
        }

        private void logopngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Hide();
        }

        private void DisplaySocietiesDetails()
        {
            DataTable societiesTable = GetSocietiesDataFromDatabase();
            int top = 10;
            foreach (DataRow row in societiesTable.Rows)
            {
                string societyName = row["name"].ToString();
                string societyDescription = row["description"].ToString();
                string presidentName = GetPresidentNameFromId(Convert.ToInt32(row["president_id"]));
                string status = row["status"].ToString();
                if (status != "approved")
                    continue;

                Panel societyPanel = new Panel();
                societyPanel.BorderStyle = BorderStyle.FixedSingle;
                societyPanel.Width = tableLayoutPanel1.Width - 40;
                societyPanel.Padding = new Padding(10);

                Label nameLabel = new Label();
                nameLabel.Text = $"Society Name: {societyName}";
                nameLabel.AutoSize = true;
                nameLabel.Location = new System.Drawing.Point(10, 10);
                societyPanel.Controls.Add(nameLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $"Description: {societyDescription}";
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new System.Drawing.Point(10, 30);
                societyPanel.Controls.Add(descriptionLabel);

                Label presidentLabel = new Label();
                presidentLabel.Text = $"President: {presidentName}";
                presidentLabel.AutoSize = true;
                presidentLabel.Location = new System.Drawing.Point(10, 50);
                societyPanel.Controls.Add(presidentLabel);

                Button joinButton = new Button();
                joinButton.Text = "Join";
                joinButton.Tag = Convert.ToInt32(row["society_id"]); 
                joinButton.AutoSize = true;
                joinButton.Location = new System.Drawing.Point(10, 70);
                joinButton.Click += JoinButton_Click; 
                societyPanel.Controls.Add(joinButton);

                societyPanel.Location = new System.Drawing.Point(20, top);
                tableLayoutPanel1.Controls.Add(societyPanel);

                top += societyPanel.Height + 10;
            }
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            userID = Login.userId;
            if (userID < 0)
            {
                MessageBox.Show("Login to continue!");
                return;
            }
            Button joinButton = (Button)sender;
            int societyId = (int)joinButton.Tag; 

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO society_members (user_id, society_id, role) VALUES (@userId, @societyId, @role)";
                command.Parameters.AddWithValue("@userId", userID); 
                command.Parameters.AddWithValue("@societyId", societyId);
                command.Parameters.AddWithValue("@role", "member"); 
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Joined the society successfully!");
        }

        private string GetPresidentNameFromId(int presidentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT username FROM users WHERE user_id = @userId";
                command.Parameters.AddWithValue("@userId", presidentId);
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown";
            }
        }
        private DataTable GetSocietiesDataFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM societies";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private void createASocietyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createSociety createSocietyPage = new createSociety();
            createSocietyPage.Show();
            this.Hide();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
