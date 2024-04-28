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
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Societies_Management_System
{
    public partial class LandingPage : Form
    {
        public static int userID;
        string connectionString = "Data Source=DESKTOP-CD9SUPU\\SQLEXPRESS;Initial Catalog=society;Integrated Security=True;";

        public LandingPage()
        {
            InitializeComponent();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            userID = Login.userId;
            if (userID == 1)//admin user_id
            {
                dataGridView1.Visible = true;
                DataTable societies = GetSocietiesToApprove();
                dataGridView1.DataSource = societies;
                DataGridViewButtonColumn approveButtonColumn = new DataGridViewButtonColumn();
                approveButtonColumn.Name = "ApproveButton";
                approveButtonColumn.HeaderText = "Approve";
                approveButtonColumn.Text = "Approve";
                approveButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(approveButtonColumn);

                DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
                rejectButtonColumn.Name = "RejectButton";
                rejectButtonColumn.HeaderText = "Reject";
                rejectButtonColumn.Text = "Reject";
                rejectButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(rejectButtonColumn);
            }
        }

        private DataTable GetSocietiesToApprove()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT society_id, name, description FROM societies WHERE status = 'pending'";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    int societyId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["society_id"].Value);

                    if (dataGridView1.Columns[e.ColumnIndex].Name == "ApproveButton")
                    {
                        ApproveSociety(societyId);
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "RejectButton")
                    {
                        RejectSociety(societyId);
                    }

                    
                    DataTable societies = GetSocietiesToApprove();
                    dataGridView1.DataSource = societies;
                }
            }
        }

        private void RejectSociety(int societyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE societies SET status = 'rejected' WHERE society_id = @societyId";
                command.Parameters.AddWithValue("@societyId", societyId);
                command.ExecuteNonQuery();
            }
        }

        private void ApproveSociety(int societyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE societies SET status = 'approved' WHERE society_id = @societyId";
                command.Parameters.AddWithValue("@societyId", societyId);
                command.ExecuteNonQuery();
            }
        }
        private void viewEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Events eventsPage = new Events();
            eventsPage.Show();
            this.Hide();
        }

        private void lOGOpngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Hide();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login LoginPage = new Login();
            LoginPage.Show();
            this.Hide();
        }

        private void signupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var signupPage = new Signup();
            signupPage.Show();
            this.Hide();
        }

        private void viewSocietiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Societies Societies = new Societies();
            Societies.Show();
            this.Hide();
        }

        private void mySocietiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySocieties mySocieties = new MySocieties();
            mySocieties.Show(); 
            this.Hide();
        }
    }
}
