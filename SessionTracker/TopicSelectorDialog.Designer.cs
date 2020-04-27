namespace SessionTracker
{
    partial class TopicSelectorDialog
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
            this.topicsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.topicsSaveBtn = new System.Windows.Forms.Button();
            this.topicsCancelBtn = new System.Windows.Forms.Button();
            this.topicsAddBtn = new System.Windows.Forms.Button();
            this.topicsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topicsCollapsePanelBtn = new System.Windows.Forms.Button();
            this.topicsExpandPanelBtn = new System.Windows.Forms.Button();
            this.topicsLabel = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.topicsCourseTopicsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.topicsCourseListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.topicsAddInstructionsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.topicsSplitContainer)).BeginInit();
            this.topicsSplitContainer.Panel1.SuspendLayout();
            this.topicsSplitContainer.Panel2.SuspendLayout();
            this.topicsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // topicsCheckedListBox
            // 
            this.topicsCheckedListBox.FormattingEnabled = true;
            this.topicsCheckedListBox.Location = new System.Drawing.Point(12, 29);
            this.topicsCheckedListBox.Name = "topicsCheckedListBox";
            this.topicsCheckedListBox.Size = new System.Drawing.Size(201, 429);
            this.topicsCheckedListBox.TabIndex = 0;
            // 
            // topicsSaveBtn
            // 
            this.topicsSaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.topicsSaveBtn.Location = new System.Drawing.Point(12, 488);
            this.topicsSaveBtn.Name = "topicsSaveBtn";
            this.topicsSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.topicsSaveBtn.TabIndex = 1;
            this.topicsSaveBtn.Text = "Save";
            this.topicsSaveBtn.UseVisualStyleBackColor = true;
            this.topicsSaveBtn.Click += new System.EventHandler(this.topicsSaveBtn_Click);
            // 
            // topicsCancelBtn
            // 
            this.topicsCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.topicsCancelBtn.Location = new System.Drawing.Point(138, 488);
            this.topicsCancelBtn.Name = "topicsCancelBtn";
            this.topicsCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.topicsCancelBtn.TabIndex = 2;
            this.topicsCancelBtn.Text = "Cancel";
            this.topicsCancelBtn.UseVisualStyleBackColor = true;
            // 
            // topicsAddBtn
            // 
            this.topicsAddBtn.Location = new System.Drawing.Point(24, 104);
            this.topicsAddBtn.Name = "topicsAddBtn";
            this.topicsAddBtn.Size = new System.Drawing.Size(75, 23);
            this.topicsAddBtn.TabIndex = 3;
            this.topicsAddBtn.Text = "Add";
            this.topicsAddBtn.UseVisualStyleBackColor = true;
            this.topicsAddBtn.Click += new System.EventHandler(this.topicsAddBtn_Click);
            // 
            // topicsSplitContainer
            // 
            this.topicsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topicsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.topicsSplitContainer.Name = "topicsSplitContainer";
            // 
            // topicsSplitContainer.Panel1
            // 
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsCollapsePanelBtn);
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsExpandPanelBtn);
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsLabel);
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsCancelBtn);
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsCheckedListBox);
            this.topicsSplitContainer.Panel1.Controls.Add(this.topicsSaveBtn);
            // 
            // topicsSplitContainer.Panel2
            // 
            this.topicsSplitContainer.Panel2.Controls.Add(this.checkedListBox1);
            this.topicsSplitContainer.Panel2.Controls.Add(this.button2);
            this.topicsSplitContainer.Panel2.Controls.Add(this.label1);
            this.topicsSplitContainer.Panel2.Controls.Add(this.button1);
            this.topicsSplitContainer.Panel2.Controls.Add(this.topicsCourseTopicsListBox);
            this.topicsSplitContainer.Panel2.Controls.Add(this.label2);
            this.topicsSplitContainer.Panel2.Controls.Add(this.topicsCourseListBox);
            this.topicsSplitContainer.Panel2.Controls.Add(this.textBox1);
            this.topicsSplitContainer.Panel2.Controls.Add(this.topicsAddInstructionsLabel);
            this.topicsSplitContainer.Panel2.Controls.Add(this.topicsAddBtn);
            this.topicsSplitContainer.Panel2Collapsed = true;
            this.topicsSplitContainer.Size = new System.Drawing.Size(282, 533);
            this.topicsSplitContainer.SplitterDistance = 114;
            this.topicsSplitContainer.TabIndex = 4;
            // 
            // topicsCollapsePanelBtn
            // 
            this.topicsCollapsePanelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicsCollapsePanelBtn.Location = new System.Drawing.Point(229, 240);
            this.topicsCollapsePanelBtn.Name = "topicsCollapsePanelBtn";
            this.topicsCollapsePanelBtn.Size = new System.Drawing.Size(47, 23);
            this.topicsCollapsePanelBtn.TabIndex = 7;
            this.topicsCollapsePanelBtn.Text = "<<";
            this.topicsCollapsePanelBtn.UseVisualStyleBackColor = true;
            this.topicsCollapsePanelBtn.Click += new System.EventHandler(this.topicsCollapsePanelBtn_Click);
            // 
            // topicsExpandPanelBtn
            // 
            this.topicsExpandPanelBtn.Location = new System.Drawing.Point(229, 211);
            this.topicsExpandPanelBtn.Name = "topicsExpandPanelBtn";
            this.topicsExpandPanelBtn.Size = new System.Drawing.Size(47, 23);
            this.topicsExpandPanelBtn.TabIndex = 6;
            this.topicsExpandPanelBtn.Text = ">>";
            this.topicsExpandPanelBtn.UseVisualStyleBackColor = true;
            this.topicsExpandPanelBtn.Click += new System.EventHandler(this.topicsExpandPanelBtn_Click);
            // 
            // topicsLabel
            // 
            this.topicsLabel.AutoSize = true;
            this.topicsLabel.Location = new System.Drawing.Point(12, 9);
            this.topicsLabel.Name = "topicsLabel";
            this.topicsLabel.Size = new System.Drawing.Size(50, 17);
            this.topicsLabel.TabIndex = 2;
            this.topicsLabel.Text = "Topics";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(24, 353);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(388, 89);
            this.checkedListBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select a topic to remove from this course";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(24, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // topicsCourseTopicsListBox
            // 
            this.topicsCourseTopicsListBox.FormattingEnabled = true;
            this.topicsCourseTopicsListBox.ItemHeight = 16;
            this.topicsCourseTopicsListBox.Location = new System.Drawing.Point(245, 179);
            this.topicsCourseTopicsListBox.Name = "topicsCourseTopicsListBox";
            this.topicsCourseTopicsListBox.Size = new System.Drawing.Size(167, 84);
            this.topicsCourseTopicsListBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select a different course to copy its topics";
            // 
            // topicsCourseListBox
            // 
            this.topicsCourseListBox.FormattingEnabled = true;
            this.topicsCourseListBox.ItemHeight = 16;
            this.topicsCourseListBox.Location = new System.Drawing.Point(24, 179);
            this.topicsCourseListBox.Name = "topicsCourseListBox";
            this.topicsCourseListBox.Size = new System.Drawing.Size(171, 84);
            this.topicsCourseListBox.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 69);
            this.textBox1.TabIndex = 5;
            // 
            // topicsAddInstructionsLabel
            // 
            this.topicsAddInstructionsLabel.AutoSize = true;
            this.topicsAddInstructionsLabel.Location = new System.Drawing.Point(21, 9);
            this.topicsAddInstructionsLabel.Name = "topicsAddInstructionsLabel";
            this.topicsAddInstructionsLabel.Size = new System.Drawing.Size(292, 17);
            this.topicsAddInstructionsLabel.TabIndex = 4;
            this.topicsAddInstructionsLabel.Text = "Enter topics to add in a comma separated list";
            // 
            // TopicSelectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 533);
            this.Controls.Add(this.topicsSplitContainer);
            this.Name = "TopicSelectorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Topics";
            this.topicsSplitContainer.Panel1.ResumeLayout(false);
            this.topicsSplitContainer.Panel1.PerformLayout();
            this.topicsSplitContainer.Panel2.ResumeLayout(false);
            this.topicsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topicsSplitContainer)).EndInit();
            this.topicsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox topicsCheckedListBox;
        private System.Windows.Forms.Button topicsSaveBtn;
        private System.Windows.Forms.Button topicsCancelBtn;
        private System.Windows.Forms.Button topicsAddBtn;
        private System.Windows.Forms.SplitContainer topicsSplitContainer;
        private System.Windows.Forms.Button topicsCollapsePanelBtn;
        private System.Windows.Forms.Button topicsExpandPanelBtn;
        private System.Windows.Forms.Label topicsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox topicsCourseListBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label topicsAddInstructionsLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox topicsCourseTopicsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}