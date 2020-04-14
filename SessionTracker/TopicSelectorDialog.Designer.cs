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
            this.SuspendLayout();
            // 
            // topicsCheckedListBox
            // 
            this.topicsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.topicsCheckedListBox.FormattingEnabled = true;
            this.topicsCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.topicsCheckedListBox.Name = "topicsCheckedListBox";
            this.topicsCheckedListBox.Size = new System.Drawing.Size(287, 378);
            this.topicsCheckedListBox.TabIndex = 0;
            // 
            // topicsSaveBtn
            // 
            this.topicsSaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.topicsSaveBtn.Location = new System.Drawing.Point(12, 401);
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
            this.topicsCancelBtn.Location = new System.Drawing.Point(200, 401);
            this.topicsCancelBtn.Name = "topicsCancelBtn";
            this.topicsCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.topicsCancelBtn.TabIndex = 2;
            this.topicsCancelBtn.Text = "Cancel";
            this.topicsCancelBtn.UseVisualStyleBackColor = true;
            // 
            // TopicSelectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 450);
            this.Controls.Add(this.topicsCancelBtn);
            this.Controls.Add(this.topicsSaveBtn);
            this.Controls.Add(this.topicsCheckedListBox);
            this.Name = "TopicSelectorDialog";
            this.Text = "TopicSelectorDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox topicsCheckedListBox;
        private System.Windows.Forms.Button topicsSaveBtn;
        private System.Windows.Forms.Button topicsCancelBtn;
    }
}