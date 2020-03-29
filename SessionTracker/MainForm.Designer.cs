namespace SessionTracker
{
    partial class SessionTrackerMainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sessionTrackerTabs = new System.Windows.Forms.TabPage();
            this.sessionDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.getSessionDataWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.sessionTrackerTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sessionTrackerTabs);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // sessionTrackerTabs
            // 
            this.sessionTrackerTabs.Controls.Add(this.sessionDataGridView);
            this.sessionTrackerTabs.Location = new System.Drawing.Point(4, 25);
            this.sessionTrackerTabs.Name = "sessionTrackerTabs";
            this.sessionTrackerTabs.Padding = new System.Windows.Forms.Padding(3);
            this.sessionTrackerTabs.Size = new System.Drawing.Size(673, 421);
            this.sessionTrackerTabs.TabIndex = 0;
            this.sessionTrackerTabs.Text = "tabPage1";
            this.sessionTrackerTabs.UseVisualStyleBackColor = true;
            // 
            // sessionDataGridView
            // 
            this.sessionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionDataGridView.Location = new System.Drawing.Point(6, 6);
            this.sessionDataGridView.Name = "sessionDataGridView";
            this.sessionDataGridView.RowTemplate.Height = 24;
            this.sessionDataGridView.Size = new System.Drawing.Size(659, 150);
            this.sessionDataGridView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1272, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // getSessionDataWorker
            // 
            this.getSessionDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getSessionDataWorker_DoWork);
            // 
            // SessionTrackerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "SessionTrackerMainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.sessionTrackerTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sessionTrackerTabs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView sessionDataGridView;
        private System.ComponentModel.BackgroundWorker getSessionDataWorker;
    }
}

