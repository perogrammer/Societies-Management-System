using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Societies_Management_System
{
    public partial class SocietyDetails : Form
    {
        public static int societyId;
        public static int userID;
        public static bool isPresident = false;
        private string connectionString = "Data Source=DESKTOP-CD9SUPU\\SQLEXPRESS;Initial Catalog=society;Integrated Security=True;";
        public SocietyDetails(int societyID)
        {
            InitializeComponent();
            userID = Login.userId;
            societyId = societyID;
            DisplayMembers();
            DisplayEvents();
            if (!IsSocietyPresident(userID,societyID))
            {
                assignTaskToolStripMenuItem.Visible= false;
            }
        }
        private bool IsSocietyPresident(int userId, int societyId)
        {
            isPresident = false;
            try
            {
                string query = "SELECT COUNT(*) FROM societies WHERE president_id = @userId AND society_id = @societyId";

                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@societyId", societyId);
                DatabaseHandler dbHandler = new DatabaseHandler();
                int count = (int)dbHandler.ExecuteQueryScalar(command);

                if (count > 0)
                {
                    isPresident = true;
                }
                return isPresident;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void DisplayEvents()
        {
           
            DataTable eventsTable = GetEventsDataFromDatabase(societyId);

      
            dataGridViewEvents.DataSource = eventsTable;
        }
        private void DisplayMembers()
        {
            
            DataTable membersTable = GetMembersDataFromDatabase(societyId);

            
            dataGridViewMembers.DataSource = membersTable;
        }
        private DataTable GetMembersDataFromDatabase(int societyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT sm.member_id, u.username, sm.role " +
                                      "FROM society_members sm " +
                                      "JOIN users u ON sm.user_id = u.user_id " +
                                      "WHERE sm.society_id = @societyId order by role desc";
                command.Parameters.AddWithValue("@societyId", societyId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }


        private DataTable GetEventsDataFromDatabase(int societyId)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select event_id,name,description,event_date,location from events WHERE society_id = 1;";
                command.Parameters.AddWithValue("@societyId", societyId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void logopngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySocieties Societies = new MySocieties();
            Societies.Show();
            this.Hide();
            
        }

        private void submitFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(); 
            feedback.Show();    
            this.Hide();
        }

        private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void assignTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignTask assignTask = new AssignTask();  
            assignTask.Show();
            this.Hide();
        }

        private void announcemetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Announcements announcements = new Announcements();
            announcements.Show();   
            this.Hide();
        }
        
    }
}
