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
        public IList<Topic> SelectedTopics { get; private set; }

        public TopicSelectorDialog(BindingList<Topic> topics)
        {
            InitializeComponent();
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
    }
}
