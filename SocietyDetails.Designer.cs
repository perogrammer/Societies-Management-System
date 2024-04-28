namespace Societies_Management_System
{
    partial class SocietyDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logopngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.announcementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewMembers = new System.Windows.Forms.DataGridView();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logopngToolStripMenuItem,
            this.submitFeedbackToolStripMenuItem,
            this.announcementsToolStripMenuItem,
            this.assignTaskToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logopngToolStripMenuItem
            // 
            this.logopngToolStripMenuItem.Name = "logopngToolStripMenuItem";
            this.logopngToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logopngToolStripMenuItem.Text = "Back";
            this.logopngToolStripMenuItem.Click += new System.EventHandler(this.logopngToolStripMenuItem_Click);
            // 
            // submitFeedbackToolStripMenuItem
            // 
            this.submitFeedbackToolStripMenuItem.Name = "submitFeedbackToolStripMenuItem";
            this.submitFeedbackToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.submitFeedbackToolStripMenuItem.Text = "Submit Feedback";
            this.submitFeedbackToolStripMenuItem.Click += new System.EventHandler(this.submitFeedbackToolStripMenuItem_Click);
            // 
            // announcementsToolStripMenuItem
            // 
            this.announcementsToolStripMenuItem.Name = "announcementsToolStripMenuItem";
            this.announcementsToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.announcementsToolStripMenuItem.Text = "Announcements";
            this.announcementsToolStripMenuItem.Click += new System.EventHandler(this.announcemetsToolStripMenuItem_Click);
            // 
            // assignTaskToolStripMenuItem
            // 
            this.assignTaskToolStripMenuItem.Name = "assignTaskToolStripMenuItem";
            this.assignTaskToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.assignTaskToolStripMenuItem.Text = "Task Management";
            this.assignTaskToolStripMenuItem.Click += new System.EventHandler(this.assignTaskToolStripMenuItem_Click);
            // 
            // dataGridViewMembers
            // 
            this.dataGridViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMembers.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewMembers.Name = "dataGridViewMembers";
            this.dataGridViewMembers.Size = new System.Drawing.Size(800, 205);
            this.dataGridViewMembers.TabIndex = 3;
            this.dataGridViewMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMembers_CellContentClick);
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(0, 238);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.Size = new System.Drawing.Size(800, 200);
            this.dataGridViewEvents.TabIndex = 4;
            // 
            // SocietyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.dataGridViewMembers);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "SocietyDetails";
            this.Text = "Society Details";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logopngToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewMembers;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.ToolStripMenuItem submitFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem announcementsToolStripMenuItem;
    }
}