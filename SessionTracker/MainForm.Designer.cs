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
            this.portalTab = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.getSessionDataWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.sessionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).BeginInit();
            this.editTab.SuspendLayout();
            this.portalTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.editTab.Controls.Add(this.groupBox1);
            this.editTab.Location = new System.Drawing.Point(4, 25);
            this.editTab.Name = "editTab";
            this.editTab.Padding = new System.Windows.Forms.Padding(3);
            this.editTab.Size = new System.Drawing.Size(673, 421);
            this.editTab.TabIndex = 1;
            this.editTab.Text = "Edit";
            this.editTab.UseVisualStyleBackColor = true;
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
            // getSessionDataWorker
            // 
            this.getSessionDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getSessionDataWorker_DoWork);
            this.getSessionDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getSignInDataWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 407);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 22);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(642, 313);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            this.editTab.ResumeLayout(false);
            this.portalTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

