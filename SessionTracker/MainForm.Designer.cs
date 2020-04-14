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
            this.sessionsTab = new System.Windows.Forms.TabPage();
            this.sessionDataGridView = new System.Windows.Forms.DataGridView();
            this.editTab = new System.Windows.Forms.TabPage();
            this.getSessionDataWorker = new System.ComponentModel.BackgroundWorker();
            this.portalTab = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabControl1.SuspendLayout();
            this.sessionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).BeginInit();
            this.portalTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sessionsTab);
            this.tabControl1.Controls.Add(this.editTab);
            this.tabControl1.Controls.Add(this.portalTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // sessionsTab
            // 
            this.sessionsTab.Controls.Add(this.sessionDataGridView);
            this.sessionsTab.Location = new System.Drawing.Point(4, 25);
            this.sessionsTab.Name = "sessionsTab";
            this.sessionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.sessionsTab.Size = new System.Drawing.Size(673, 421);
            this.sessionsTab.TabIndex = 0;
            this.sessionsTab.Text = "Sessions";
            this.sessionsTab.UseVisualStyleBackColor = true;
            // 
            // sessionDataGridView
            // 
            this.sessionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sessionDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.sessionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.sessionDataGridView.Location = new System.Drawing.Point(3, 3);
            this.sessionDataGridView.Name = "sessionDataGridView";
            this.sessionDataGridView.RowTemplate.Height = 24;
            this.sessionDataGridView.Size = new System.Drawing.Size(667, 415);
            this.sessionDataGridView.TabIndex = 0;
            this.sessionDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sessionDataGridView_CellBeginEdit);
            this.sessionDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sessionDataGridView_CellClick);
            this.sessionDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sessionDataGridView_CellContentClick);
            this.sessionDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sessionDataGridView_CellEndEdit);
            // 
            // editTab
            // 
            this.editTab.Location = new System.Drawing.Point(4, 25);
            this.editTab.Name = "editTab";
            this.editTab.Padding = new System.Windows.Forms.Padding(3);
            this.editTab.Size = new System.Drawing.Size(673, 421);
            this.editTab.TabIndex = 1;
            this.editTab.Text = "Edit";
            this.editTab.UseVisualStyleBackColor = true;
            // 
            // getSessionDataWorker
            // 
            this.getSessionDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getSessionDataWorker_DoWork);
            // 
            // portalTab
            // 
            this.portalTab.Controls.Add(this.webBrowser);
            this.portalTab.Location = new System.Drawing.Point(4, 25);
            this.portalTab.Name = "portalTab";
            this.portalTab.Size = new System.Drawing.Size(673, 421);
            this.portalTab.TabIndex = 2;
            this.portalTab.Text = "Portal";
            this.portalTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(673, 421);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("https://ilctimetrk.waketech.edu/admin", System.UriKind.Absolute);
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
            this.sessionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).EndInit();
            this.portalTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sessionsTab;
        private System.Windows.Forms.TabPage editTab;
        private System.ComponentModel.BackgroundWorker getSessionDataWorker;
        private System.Windows.Forms.DataGridView sessionDataGridView;
        private System.Windows.Forms.TabPage portalTab;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

