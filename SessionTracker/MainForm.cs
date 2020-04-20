using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Database;
using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using SessionTracker.Modules.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace SessionTracker
{
    public partial class SessionTrackerMainForm : Form
    {
        private static readonly string LogDataURL = @"https://ilctimetrk.waketech.edu/admin/live-status?_=";
        private static readonly int DataRequestInterval = 30000;

        private readonly string activeCookie;
        private readonly Campus activeCampus;
        private readonly IDatabase database;
        private readonly IMessageHandler messageHandler;
        private Timer eventTimer;

        private DatabaseReader dataReader;
        private DatabaseWriter dataWriter;

        private bool canUpdate = true;
        private IList<SignInData> signInDataBuffer;
        private HashSet<SignInData> loggedSessionCache;

        public SessionTrackerMainForm(IDatabase database, IMessageHandler messageHandler, string cookie, Campus campus)
        {
            InitializeComponent();

            this.activeCookie = cookie;
            this.activeCampus = campus;
            this.database = database;
            this.messageHandler = messageHandler;
            this.dataReader = new DatabaseReader();
            this.dataWriter = new DatabaseWriter();
            this.signInDataBuffer = new BindingList<SignInData>();
            this.loggedSessionCache = new HashSet<SignInData>();
            
            this.Text = $"Session Tracker - {this.activeCampus.Name}";

            this.InitializeDataGridView();
            this.StartBackgroundWorker();
        }

        private void InitializeDataGridView()
        {
            BindingList<SignInData> signIns = this.GetSignInData();
            BindingSource source = new BindingSource(signIns, null);

            sessionDataGridView.AutoGenerateColumns = true;
            sessionDataGridView.DataSource = source;

            foreach(DataGridViewColumn c in sessionDataGridView.Columns)
            {
                c.ReadOnly = true;
            }

            DataGridViewComboBoxColumn tutorSelectorColumn = new DataGridViewComboBoxColumn();
            tutorSelectorColumn.DisplayMember = "FullName";
            tutorSelectorColumn.ValueMember = "ID";

            this.dataReader.Command = new GetTutorsByCampusCommand(this.database, this.activeCampus.Name);
            BindingList<Tutor> tutors = new BindingList<Tutor>();

            foreach (NameValueCollection item in this.dataReader.ExecuteCommand())
            {
                tutors.Add(
                    new Tutor(
                        Convert.ToInt32(item["ID"]),
                        item["FName"],
                        item["LName"],
                        Convert.ToBoolean(Convert.ToInt32(item["IsActive"]))
                    )
                );
            }

            source = new BindingSource(tutors, null);
            tutorSelectorColumn.DataSource = source;
            tutorSelectorColumn.Name = "Tutor";
            tutorSelectorColumn.HeaderText = tutorSelectorColumn.Name;
            sessionDataGridView.Columns.Add(tutorSelectorColumn);

            DataGridViewTextBoxColumn topicSelectorColumn = new DataGridViewTextBoxColumn();
            topicSelectorColumn.Name = "Topics";
            topicSelectorColumn.HeaderText = topicSelectorColumn.Name;
            topicSelectorColumn.ReadOnly = true;
            topicSelectorColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            sessionDataGridView.Columns.Add(topicSelectorColumn);

            DataGridViewTextBoxColumn notesColumn = new DataGridViewTextBoxColumn();
            notesColumn.Name = "Notes";
            notesColumn.HeaderText = notesColumn.Name;
            sessionDataGridView.Columns.Add(notesColumn);

            DataGridViewCheckBoxColumn isWorkshopColumn = new DataGridViewCheckBoxColumn();
            isWorkshopColumn.FalseValue = false;
            isWorkshopColumn.TrueValue = true;
            isWorkshopColumn.IndeterminateValue = false;
            isWorkshopColumn.Name = "IsWorkshop";
            isWorkshopColumn.HeaderText = isWorkshopColumn.Name;
            sessionDataGridView.Columns.Add(isWorkshopColumn);

            DataGridViewButtonColumn logButtonColumn = new DataGridViewButtonColumn();
            logButtonColumn.Name = "LogBtns";
            logButtonColumn.Text = "Log";
            logButtonColumn.UseColumnTextForButtonValue = true;
            sessionDataGridView.Columns.Add(logButtonColumn);
        }

        private void StartBackgroundWorker()
        {
            this.eventTimer = new Timer();
            this.eventTimer.Interval = DataRequestInterval;
            this.eventTimer.Tick += UpdateSignInData;
            this.eventTimer.Start();
        }

        private BindingList<SignInData> GetSignInData()
        {
            IRequestHandler<BindingList<SignInData>, DataRequestPayload> requestHandler = new DataRequest(this.messageHandler);
            DataRequestPayload payload = new DataRequestPayload(this.activeCookie, this.activeCampus);
            return requestHandler.MakeRequest(LogDataURL, payload);
        }

        private NameValueCollection CreateSession(SignInData data, DataGridViewCellCollection cells)
        {
            this.dataReader.Command = new GetLastInsertedRowIDCommand(this.database, "Session");
            NameValueCollection sessionData = new NameValueCollection();

            var id = this.dataReader.ExecuteCommand().FirstOrDefault();
            string sessionID = id == null ? "0" : (Convert.ToInt32(id[0]) + 1).ToString();

            sessionData.Add("ID", sessionID);
            sessionData.Add("StudentID", data.StudentID);
            sessionData.Add("Timestamp", data.Timestamp.ToString());
            sessionData.Add("FName", data.FName);
            sessionData.Add("LName", data.LName);
            sessionData.Add("Notes", cells["Notes"].Value.ToString());
            sessionData.Add("IsWorkshop", Convert.ToBoolean(cells["IsWorkshop"].Value).ToString());

            
            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Campus", "Name", cells["Campus"].Value.ToString());
            string campusID = this.dataReader.ExecuteCommand().First()[0];
            sessionData.Add("CampusID", campusID);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Course", "Name", cells["Course"].Value.ToString());
            string courseID = this.dataReader.ExecuteCommand().First()[0];
            sessionData.Add("CourseID", courseID);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Center", "Name", cells["Center"].Value.ToString());
            string centerID = this.dataReader.ExecuteCommand().First()[0];
            sessionData.Add("CenterID", centerID);

            sessionData.Add("TutorID", cells["Tutor"].Value.ToString());
            sessionData.Add("Topics", cells["Topics"].Value.ToString());
            
            return sessionData;
        }

        private void UpdateSignInData(Object obj, EventArgs e)
        {
            this.eventTimer.Stop();
            getSessionDataWorker.RunWorkerAsync();
        }

        private void getSessionDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = this.GetSignInData();                           
        }

        //TODO: Filter out sessions that have already been logged.
        private void getSignInDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(canUpdate)
            {
                var rows = sessionDataGridView.Rows;
                IList<SignInData> currentSignInData = new List<SignInData>();

                foreach(DataGridViewRow row in rows)
                {
                    currentSignInData.Add((SignInData)row.DataBoundItem);
                }

                foreach(SignInData element in (BindingList<SignInData>)e.Result)
                {
                    if(!currentSignInData.Contains(element) && !IsLogged(element))
                    {
                        BindingSource source = (BindingSource)sessionDataGridView.DataSource;
                        ((BindingList<SignInData>)source.DataSource).Add(element);
                    }
                }

                if(this.signInDataBuffer.Count > 0)
                {
                    foreach (SignInData element in this.signInDataBuffer)
                    {
                        if (!this.signInDataBuffer.Contains(element))
                        {
                            ((BindingSource)sessionDataGridView.DataSource).List.Add(element);
                        }
                    }
                }
            }
            else
            {
                foreach (SignInData element in (BindingList<SignInData>)e.Result)
                    if(!this.signInDataBuffer.Contains(element))
                        this.signInDataBuffer.Add(element);
            }

            this.eventTimer.Start();
        }

        private bool IsLogged(SignInData element)
        {
            return this.loggedSessionCache.Contains(element);

        }

        private void sessionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                SignInData data = (SignInData)senderGrid.CurrentRow.DataBoundItem;
                DataGridViewCellCollection cells = senderGrid.CurrentRow.Cells;
                NameValueCollection session = CreateSession(data, cells);

                this.dataWriter.Command = new LogSessionCommand(this.database, session);

                try
                {
                    int rowsInserted = this.dataWriter.ExecuteCommand();
                    
                    if(rowsInserted == 0)
                    {
                        this.messageHandler.ShowDialog("Logging Error", "Failed to log session. Please try again.", MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.loggedSessionCache.Add(data);
                        senderGrid.Rows.Remove(senderGrid.CurrentRow);
                    }
                }
                catch(SQLiteException ex)
                {
                    this.messageHandler.ShowDialog("Database Error", ex.Message, MessageBoxIcon.Error);
                }
            } 
        }

        private void sessionDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.canUpdate = false;
        }

        private void sessionDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.canUpdate = true;
        }

        private void sessionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name == "Topics" && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                //TODO: add error handing
                string courseName = senderGrid.CurrentRow.Cells["Course"].Value.ToString();

                this.dataReader.Command = new GetTopicsByCourseCommand(this.database, courseName);
                BindingList<Topic> topics = new BindingList<Topic>();

                foreach (var item in this.dataReader.ExecuteCommand())
                {
                    topics.Add(
                        new Topic(
                            Convert.ToInt32(item["ID"]),
                            item["Name"]
                        )
                    );
                }

                TopicSelectorDialog topicSelectorDialog = new TopicSelectorDialog(topics);

                if(topicSelectorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (topicSelectorDialog.SelectedTopics.Count > 0)
                    {
                        string topicsDisplay = "";

                        foreach (Topic topic in topicSelectorDialog.SelectedTopics)
                        {
                            topicsDisplay += $"{topic.ToString()}, ";
                        }

                        topicsDisplay = topicsDisplay.TrimEnd(',', ' ');
                        senderGrid.CurrentCell.Value = topicsDisplay;

                    }
                    else
                    {
                        senderGrid.CurrentCell.Value = null;
                    }

                    topicSelectorDialog.ClearSelectedTopics();
                    senderGrid.Refresh();

                }
            }
        }
    }
}
