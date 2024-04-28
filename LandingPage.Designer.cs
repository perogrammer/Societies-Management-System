namespace Societies_Management_System
{
    partial class LandingPage
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
            this.lOGOpngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSocieitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.viewSocietiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySocietiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOGOpngToolStripMenuItem,
            this.viewSocieitiesToolStripMenuItem,
            this.viewEventsToolStripMenuItem,
            this.signupToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.viewSocietiesToolStripMenuItem,
            this.mySocietiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lOGOpngToolStripMenuItem
            // 
            this.lOGOpngToolStripMenuItem.Name = "lOGOpngToolStripMenuItem";
            this.lOGOpngToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.lOGOpngToolStripMenuItem.Text = "Home";
            this.lOGOpngToolStripMenuItem.Click += new System.EventHandler(this.lOGOpngToolStripMenuItem_Click);
            // 
            // viewSocieitiesToolStripMenuItem
            // 
            this.viewSocieitiesToolStripMenuItem.Name = "viewSocieitiesToolStripMenuItem";
            this.viewSocieitiesToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // viewEventsToolStripMenuItem
            // 
            this.viewEventsToolStripMenuItem.Name = "viewEventsToolStripMenuItem";
            this.viewEventsToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.viewEventsToolStripMenuItem.Text = "Upcoming Events";
            this.viewEventsToolStripMenuItem.Click += new System.EventHandler(this.viewEventsToolStripMenuItem_Click);
            // 
            // signupToolStripMenuItem
            // 
            this.signupToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.signupToolStripMenuItem.Name = "signupToolStripMenuItem";
            this.signupToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.signupToolStripMenuItem.Text = "Signup";
            this.signupToolStripMenuItem.Click += new System.EventHandler(this.signupToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // viewSocietiesToolStripMenuItem
            // 
            this.viewSocietiesToolStripMenuItem.Name = "viewSocietiesToolStripMenuItem";
            this.viewSocietiesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.viewSocietiesToolStripMenuItem.Text = "View Societies";
            this.viewSocietiesToolStripMenuItem.Click += new System.EventHandler(this.viewSocietiesToolStripMenuItem_Click);
            // 
            // mySocietiesToolStripMenuItem
            // 
            this.mySocietiesToolStripMenuItem.Name = "mySocietiesToolStripMenuItem";
            this.mySocietiesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.mySocietiesToolStripMenuItem.Text = "My Societies";
            this.mySocietiesToolStripMenuItem.Click += new System.EventHandler(this.mySocietiesToolStripMenuItem_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "LandingPage";
            this.Text = "Societies Management System";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewSocieitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGOpngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem viewSocietiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySocietiesToolStripMenuItem;
    }
}

