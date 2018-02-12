namespace Asigment_4
{
    partial class SolarSim
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
            this.components = new System.ComponentModel.Container();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.LabelDayCounter = new System.Windows.Forms.Label();
            this.LabelDay = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawSolarSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DisplayPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.AccessibleName = "DisplayPanel";
            this.DisplayPanel.Controls.Add(this.LabelDayCounter);
            this.DisplayPanel.Controls.Add(this.LabelDay);
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayPanel.Location = new System.Drawing.Point(0, 24);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(1091, 585);
            this.DisplayPanel.TabIndex = 1;
            this.DisplayPanel.Tag = "DisplayPanel";
            this.DisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPanel_Paint);
            // 
            // LabelDayCounter
            // 
            this.LabelDayCounter.AutoSize = true;
            this.LabelDayCounter.Location = new System.Drawing.Point(48, 22);
            this.LabelDayCounter.Name = "LabelDayCounter";
            this.LabelDayCounter.Size = new System.Drawing.Size(13, 13);
            this.LabelDayCounter.TabIndex = 1;
            this.LabelDayCounter.Text = "0";
            // 
            // LabelDay
            // 
            this.LabelDay.AutoSize = true;
            this.LabelDay.Location = new System.Drawing.Point(12, 22);
            this.LabelDay.Name = "LabelDay";
            this.LabelDay.Size = new System.Drawing.Size(29, 13);
            this.LabelDay.TabIndex = 0;
            this.LabelDay.Text = "Day:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.drawSolarSystemToolStripMenuItem,
            this.startSimulationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // drawSolarSystemToolStripMenuItem
            // 
            this.drawSolarSystemToolStripMenuItem.Name = "drawSolarSystemToolStripMenuItem";
            this.drawSolarSystemToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.drawSolarSystemToolStripMenuItem.Text = "Draw Solar System";
            this.drawSolarSystemToolStripMenuItem.Click += new System.EventHandler(this.drawSolarSystemToolStripMenuItem_Click);
            // 
            // startSimulationToolStripMenuItem
            // 
            this.startSimulationToolStripMenuItem.Name = "startSimulationToolStripMenuItem";
            this.startSimulationToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.startSimulationToolStripMenuItem.Text = "Start Simulation";
            this.startSimulationToolStripMenuItem.Click += new System.EventHandler(this.startSimulationToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SolarSim
            // 
            this.AccessibleName = "SolarSim";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 609);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SolarSim";
            this.Text = "Solar Simulator";
            this.Resize += new System.EventHandler(this.SolarSim_Resize);
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawSolarSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSimulationToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LabelDay;
        private System.Windows.Forms.Label LabelDayCounter;
    }
}

