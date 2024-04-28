using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class MySocieties : Form
    {
        private int userId; 
        private string connectionString = "Data Source=DESKTOP-CD9SUPU\\SQLEXPRESS;Initial Catalog=society;Integrated Security=True;";

        public MySocieties()
        {
            InitializeComponent();
            this.userId = Login.userId;
        }

        private void MySocieties_Load(object sender, EventArgs e)
        {
            DataTable societiesTable = GetMySocietiesDataFromDatabase();
            int top = 60;
            foreach (DataRow row in societiesTable.Rows)
            {
                string societyName = row["name"].ToString();
                string societyDescription = row["description"].ToString();
                string role = row["role"].ToString();

                Panel societyPanel = new Panel();
                societyPanel.BorderStyle = BorderStyle.FixedSingle;
                societyPanel.Width = tableLayoutPanel1.Width - 40;
                societyPanel.Padding = new Padding(10);

                Label nameLabel = new Label();
                nameLabel.Text = $"Society Name: {societyName}";
                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(10, 10);
                societyPanel.Controls.Add(nameLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $"Description: {societyDescription}";
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new Point(10, 30);
                societyPanel.Controls.Add(descriptionLabel);

                Label roleLabel = new Label();
                roleLabel.Text = $"Role: {role}";
                roleLabel.AutoSize = true;
                roleLabel.Location = new Point(10, 50);
                societyPanel.Controls.Add(roleLabel);

                societyPanel.Location = new Point(20, top);
                tableLayoutPanel1.Controls.Add(societyPanel);

                
                societyPanel.Click += (s, _) =>
                {
                    int societyId = Convert.ToInt32(row["society_id"]);
                    ShowSocietyDetails(societyId);
                };

                top += societyPanel.Height + 10;
            }
        }

        private DataTable GetMySocietiesDataFromDatabase()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT s.society_id, s.name, s.description, sm.role FROM societies s " +
                                      "JOIN society_members sm ON s.society_id = sm.society_id " +
                                      "WHERE sm.user_id = @userId";
                command.Parameters.AddWithValue("@userId", userId); 
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void ShowSocietyDetails(int societyId)
        {
            SocietyDetails societyDetailsForm = new SocietyDetails(societyId);
            societyDetailsForm.Show();
            this.Hide();
        }

        private void logopngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
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
