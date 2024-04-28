using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Societies_Management_System
{
    public partial class AssignTask : Form
    {
        private int societyId = SocietyDetails.societyId;
        public AssignTask()
        {
            InitializeComponent();
        }
        private void AssignTask_Load(object sender, EventArgs e)
        {
            PopulateMembersDropdown();
            DisplayTaskView();
        }
        private void PopulateMembersDropdown()
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT username FROM users " +
                                      "JOIN society_members ON users.user_id=society_members.user_id " +
                                      "WHERE society_id=@societyId";
                command.Parameters.AddWithValue("@societyId", societyId);

                DataTable result = dbHandler.ExecuteQuery(command);
                foreach (DataRow row in result.Rows)
                {
                    string username = row["username"].ToString();
                    comboBox1.Items.Add(username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetUserIdFromUsername(string username)
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT user_id FROM users WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);
                object result = dbHandler.ExecuteQueryScalar(command);
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("User not found.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }

        private bool InsertTask(string name, string description, int assignedToUserId)
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO tasks (society_id, name, description, assigned_to) VALUES (@societyId, @name, @description, @assignedToUserId)";
                command.Parameters.AddWithValue("@societyId", societyId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@assignedToUserId", assignedToUserId);
                dbHandler.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }


        private void ClearForm()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string taskName = textBox1.Text;
            string taskDescription = richTextBox1.Text;
            string assignedToUsername = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(assignedToUsername))
            {
                int assignedToUserId = GetUserIdFromUsername(assignedToUsername);
                if (assignedToUserId != -1)
                {
                    if (!string.IsNullOrEmpty(taskName) && !string.IsNullOrEmpty(taskDescription))
                    {
                        if (InsertTask(taskName, taskDescription, assignedToUserId))
                        {
                            MessageBox.Show("Task assigned successfully.");
                            ClearForm();
                            DisplayTaskView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to assign task.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter both task name and description.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to assign task. User not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a member to assign the task to.");
            }
        }
        private void DisplayTaskView()
        {
            DataTable tasksTable = GetTasksDataFromDatabase(); 
            int top = 10;
            tableLayoutPanel1.Controls.Clear();
            foreach (DataRow row in tasksTable.Rows)
            {
                string taskName = row["name"].ToString();
                string taskDescription = row["description"].ToString();
                string taskStatus = row["status"].ToString();
                if (taskStatus == "completed")
                    continue;

                Panel taskPanel = new Panel();
                taskPanel.BorderStyle = BorderStyle.None;
                taskPanel.Width = tableLayoutPanel1.Width - 10;
                taskPanel.Padding = new Padding(10);

                Label nameLabel = new Label();
                nameLabel.Text = $"Task Name: {taskName}";
                nameLabel.AutoSize = true;
                nameLabel.Location = new System.Drawing.Point(10, 10);
                taskPanel.Controls.Add(nameLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $"Description: {taskDescription}";
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new System.Drawing.Point(10, 30);
                taskPanel.Controls.Add(descriptionLabel);

                Label statusLabel = new Label();
                statusLabel.Text = $"Status: {taskStatus}";
                statusLabel.AutoSize = true;
                statusLabel.Location = new System.Drawing.Point(10, 50);
                taskPanel.Controls.Add(statusLabel);

                Button markCompletedButton = new Button();
                markCompletedButton.Text = "Mark As Completed";
                markCompletedButton.Tag = Convert.ToInt32(row["task_id"]);
                markCompletedButton.AutoSize = true;
                markCompletedButton.Location = new System.Drawing.Point(10, 70);
                markCompletedButton.Click += MarkCompletedButton_Click;
                taskPanel.Controls.Add(markCompletedButton);


                taskPanel.Location = new System.Drawing.Point(20, top);
                tableLayoutPanel1.Controls.Add(taskPanel);

                top += taskPanel.Height + 10;
            }
        }

        private void MarkCompletedButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int taskId = (int)button.Tag;

            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE tasks SET status = 'completed' WHERE task_id = @taskId";
                command.Parameters.AddWithValue("@taskId", taskId);
                int rowsAffected = dbHandler.ExecuteNonQuery(command);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Task marked as completed successfully.");
                    DisplayTaskView();
                }
                else
                {
                    MessageBox.Show("Failed to mark task as completed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private DataTable GetTasksDataFromDatabase()
        {
            try
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM tasks";
                return dbHandler.ExecuteQuery(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        private void logo0jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocietyDetails societyDetails = new SocietyDetails(societyId);
            societyDetails.Show();
            this.Hide();
        }
    }
}
