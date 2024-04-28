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
    public partial class Feedback : Form
    {
        
        public static int userID;
        public static int societyID;
        public Feedback()
        {
            InitializeComponent();
            userID = Login.userId;
            societyID = SocietyDetails.societyId;
            button1.Enabled = true;
            if (SocietyDetails.isPresident)
            {
                button1.Enabled = false;
                DisplayFeedbackView();
            }
        }
        private void DisplayFeedbackView()
        {
            DataTable tasksTable = GetFeedbackDataFromDatabase();
            int top = 10;
            tableLayoutPanel1.Controls.Clear();
            foreach (DataRow row in tasksTable.Rows)
            {
                string taskName = row["subject"].ToString();
                string taskDescription = row["message"].ToString();
                
                

                Panel feedbackPanel = new Panel();
                feedbackPanel.BorderStyle = BorderStyle.None;
                feedbackPanel.Width = tableLayoutPanel1.Width - 10;
                feedbackPanel.Padding = new Padding(10);

                Label subjectLabel = new Label();
                subjectLabel.Text = $"Subject: {taskName}";
                subjectLabel.AutoSize = true;
                subjectLabel.Location = new System.Drawing.Point(10, 10);
                feedbackPanel.Controls.Add(subjectLabel);

                Label messageLabel = new Label();
                messageLabel.Text = $"Message: {taskDescription}";
                messageLabel.AutoSize = true;
                messageLabel.Location = new System.Drawing.Point(10, 30);
                feedbackPanel.Controls.Add(messageLabel);

                
                feedbackPanel.Location = new System.Drawing.Point(20, top);
                tableLayoutPanel1.Controls.Add(feedbackPanel);

                top += feedbackPanel.Height + 10;
            }
        }

        private DataTable GetFeedbackDataFromDatabase()
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT subject, message FROM feedback WHERE society_id=@societyID";
                command.Parameters.AddWithValue("@societyID", societyID);
                return dbHandler.ExecuteQuery(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subject = textBox1.Text;
            string message = richTextBox1.Text;

            string query = "INSERT INTO feedback (user_id, society_id, subject, message) VALUES (@userId, @societyId, @subject, @message)";

            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand(query);

                command.Parameters.AddWithValue("@userId", userID);
                command.Parameters.AddWithValue("@societyId", societyID);
                command.Parameters.AddWithValue("@subject", subject);
                command.Parameters.AddWithValue("@message", message);

                int rowsAffected = dbHandler.ExecuteNonQuery(command);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Feedback submitted successfully!");
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to submit feedback.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void logo0jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocietyDetails societyDetails = new SocietyDetails(societyID);
            societyDetails.Show();
            this.Hide();
        }
    }
}
