using SessionTracker.Modules.Data.Database;
using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionTracker
{
    public partial class TopicSelectorDialog : Form
    {
        private const int CONTROL_WIDTH_COLLAPSED = 300;
        private const int CONTROL_WIDTH_EXPANDED = 740;
        private const int CONTROL_HEIGHT = 580;

        public IList<Topic> SelectedTopics { get; private set; }

        public TopicSelectorDialog(BindingList<Topic> topics)
        {
            InitializeComponent();
            this.Height = CONTROL_HEIGHT;

            this.SelectedTopics = new List<Topic>();
            BindingSource source = new BindingSource(topics, null);
            topicsCheckedListBox.DataSource = source;
        }

        private void topicsSaveBtn_Click(object sender, EventArgs e)
        {
            foreach(Topic item in topicsCheckedListBox.CheckedItems)
            {
                this.SelectedTopics.Add(new Topic(item.ID, item.Name));
            }
        }

        public void ClearSelectedTopics()
        {
            this.SelectedTopics.Clear();
        }

        private void topicsAddBtn_Click(object sender, EventArgs e)
        {
            this.Width += 50;

        }

        private void topicsExpandPanelBtn_Click(object sender, EventArgs e)
        {
            topicsSplitContainer.Panel2Collapsed = false;
            this.Width = CONTROL_WIDTH_EXPANDED;
                      
        }

        private void topicsCollapsePanelBtn_Click(object sender, EventArgs e)
        {
            topicsSplitContainer.Panel2Collapsed = true;
            this.Width = CONTROL_WIDTH_COLLAPSED;
        }
    }
}
