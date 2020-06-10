using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Database;
using SessionTracker.Modules.Data.Database.Commands;
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
        private readonly IDNamePair activeCampus;
        public readonly IDatabase database;
        private readonly IMessageHandler messageHandler;
        private Timer eventTimer;

        private bool canUpdate = true;
        private IList<SignInData> signInDataBuffer;
        private HashSet<SignInData> loggedSessionCache;

        public SessionTrackerMainForm(IDatabase database, IMessageHandler messageHandler, string cookie, IDNamePair campus)
        {
            InitializeComponent();

            this.activeCookie = cookie;
            this.activeCampus = campus;
            this.database = database;
            this.messageHandler = messageHandler;

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

            BindingList<Tutor> tutors = new BindingList<Tutor>();

            foreach (NameValueCollection item in this.GetTutorsByCampus(this.activeCampus.Name))
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

        //private NameValueCollection CollectSessionData(SignInData data, DataGridViewCellCollection cells)
        //{
        //    NameValueCollection sessionData = new NameValueCollection();

        //    string sessionID = this.GetLastSessionID();
        //    sessionData.Add("ID", sessionID);
        //    sessionData.Add("StudentID", data.StudentID);
        //    sessionData.Add("Timestamp", data.Timestamp.ToString());
        //    sessionData.Add("FName", data.FName);
        //    sessionData.Add("LName", data.LName);
        //    sessionData.Add("Notes", cells["Notes"].Value.ToString());
        //    sessionData.Add("IsWorkshop", Convert.ToBoolean(cells["IsWorkshop"].Value).ToString());

        //    string campusID = this.GetCampusID(cells["Campus"].Value.ToString());
        //    sessionData.Add("CampusID", campusID);

        //    string courseID = this.GetCourseID(cells["Course"].Value.ToString());
        //    sessionData.Add("CourseID", courseID);

        //    string centerID = this.GetCenterID(cells["center"].Value.ToString());
        //    sessionData.Add("CenterID", centerID);

        //    sessionData.Add("TutorID", cells["Tutor"].Value.ToString());
        //    sessionData.Add("Topics", cells["Topics"].Value.ToString());

        //    return sessionData;
        //}

        private Session CollectSessionData(SignInData data, DataGridViewCellCollection cells)
        {
            Session sessionData = new Session(this.GetLastSessionID());

            sessionData.StudentID = data.StudentID;
            sessionData.Timestamp = data.Timestamp;
            sessionData.FName = data.FName;
            sessionData.LName = data.LName;
            sessionData.Notes = cells["Notes"].Value.ToString();
            sessionData.IsWorkshop = Convert.ToBoolean(cells["IsWorkshop"].Value);

            //sessionData.Campus = this.GetCampusID(cells["Campus"].Value.ToString());
            //sessionData.Add("CampusID", campusID);
            sessionData.Campus = (IDNamePair)cells["Campus"].Value;

            //string courseID = this.GetCourseID(cells["Course"].Value.ToString());
            //sessionData.Add("CourseID", courseID);
            sessionData.Course = (IDNamePair)cells["Course"].Value;

            //string centerID = this.GetCenterID(cells["center"].Value.ToString());
            //sessionData.Add("CenterID", centerID);
            sessionData.Center = (IDNamePair)cells["Center"].Value;

            //sessionData.Add("TutorID", cells["Tutor"].Value.ToString());
            //sessionData.Add("Topics", cells["Topics"].Value.ToString());
            sessionData.Tutor = (Tutor)cells["Tutor"].Value;
            sessionData.Topics = this.ParseTopicsString(cells["Topics"].Value.ToString().Split(','));

            return sessionData;
        }

        private List<IDNamePair> ParseTopicsString(params string[] topics)
        {
            List<IDNamePair> result = new List<IDNamePair>();

            foreach (var name in topics)
            {
                NameValueCollection queryResult = this.database.Read(
                    DbCommandResource.SelectTopics,
                    new Dictionary<string, string>()
                    {
                        { DbCommandResource.NameParameterKey, name }
                    })
                    .FirstOrDefault();

                if(queryResult != null)
                {
                    result.Add(new IDNamePair(queryResult["ID"], queryResult["Name"]));
                }
            }

            return result;
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
                //NameValueCollection sessionData = CollectSessionData(data, cells);
                Session session = CollectSessionData(data, cells);

                try
                {
                    int rowsInserted = this.LogSession(session);

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
                string courseName = senderGrid.CurrentRow.Cells["Course"].Value.ToString();

                BindingList<IDNamePair> topics = new BindingList<IDNamePair>();

                foreach (var item in this.GetTopicsByCourse(courseName))
                {
                    topics.Add(
                        new IDNamePair(
                            item["ID"],
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

                        foreach (IDNamePair topic in topicSelectorDialog.SelectedTopics)
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

        private IEnumerable<NameValueCollection> GetTutorsByCampus(string campus)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectTutorsByCampus,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CampusParameterKey, campus }
                    });
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetLastSessionID()
        {
            try
            {
                var id = this.database.Read(
                    DbCommandResource.SelectLastRowID,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.TableParameterKey, "Session" }
                    })
                    .FirstOrDefault();

                return id == null ? "0" : (Convert.ToInt32(id[0]) + 1).ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCampusID(string campus)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCampus,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CampusParameterKey, campus }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCourseID(string course)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCourse,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CourseParameterKey, course }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCenterID(string center)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCenter,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CenterParameterKey, center }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private int LogSession(Session session)
        {
            int rowCount = 0;

            try
            {
                string studentID = this.database.Read(
                    DbCommandResource.SelectStudentByID,
                    new Dictionary<string, string>()
                    {
                        { DbCommandResource.IdParameterKey, session.ID }
                    })
                    .FirstOrDefault()[0];

                if (String.IsNullOrEmpty(studentID))
                {
                    //add student
                }


                //add session data to Session table
                //add session topic data to SessionTopic table

                return rowCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private IEnumerable<NameValueCollection> GetTopicsByCourse(string course)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectTopicsByCourse,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CourseParameterKey, course }
                    });
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
