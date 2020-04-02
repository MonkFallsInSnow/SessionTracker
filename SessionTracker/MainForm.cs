using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Database;
using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using SessionTracker.Modules.Requests;
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
    public partial class SessionTrackerMainForm : Form
    {
        private struct WorkerResult
        {
            public readonly BindingList<SignInData> SignInData;
            public readonly int SelectedRowIndex;

            public WorkerResult(BindingList<SignInData> data, int index)
            {
                this.SignInData = data;
                this.SelectedRowIndex = index;
            }
        }

        private static readonly string LogDataURL = @"https://ilctimetrk.waketech.edu/admin/live-status?_=";
        private static readonly int DataRequestInterval = 30000;

        private readonly string activeCookie;
        private readonly Campus activeCampus;
        private readonly IDatabase database;
        private readonly IMessageHandler messageHandler;
        private Timer eventTimer;

        private DatabaseReader dataReader;
        private DatabaseWriter dataWriter;

        public SessionTrackerMainForm(IDatabase database, IMessageHandler messageHandler, string cookie, Campus campus)
        {
            InitializeComponent();

            this.activeCookie = cookie;
            this.activeCampus = campus;
            this.database = database;
            this.messageHandler = messageHandler;
            this.dataReader = new DatabaseReader();
            this.dataWriter = new DatabaseWriter();

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
            DataGridViewComboBoxColumn topicSelectorColumn = new DataGridViewComboBoxColumn();
            DataGridViewColumn notesColumn = new DataGridViewColumn();
            DataGridViewButtonColumn logButtonColumn = new DataGridViewButtonColumn();

            this.dataReader.Command = new GetTutorsByCampusCommand(this.database, this.activeCampus.Name);
            BindingList<Tutor> tutors = new BindingList<Tutor>();
            foreach(var item in this.dataReader.ExecuteCommand())
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

            tutorSelectorColumn.DataSource = tutors;
            tutorSelectorColumn.HeaderText = "Tutors";
            sessionDataGridView.Columns.Add(tutorSelectorColumn);

            this.dataReader.Command = new GetTopicsCommand(this.database);
            BindingList<Topic> topics = new BindingList<Topic>();
            foreach(var item in this.dataReader.ExecuteCommand())
            {
                topics.Add(
                    new Topic(
                        Convert.ToInt32(item["ID"]),
                        item["Description"],
                        Convert.ToInt32(item["CourseID"])
                    )
                );
            }

            topicSelectorColumn.DataSource = topics;
            topicSelectorColumn.HeaderText = "Topics";
            sessionDataGridView.Columns.Add(topicSelectorColumn);

            notesColumn.HeaderText = "Notes";
            notesColumn.CellTemplate = new DataGridViewTextBoxCell();
            sessionDataGridView.Columns.Add(notesColumn);

            logButtonColumn.Text = "Log";
            logButtonColumn.UseColumnTextForButtonValue = true;
            sessionDataGridView.Columns.Add(logButtonColumn);
        }

        private void StartBackgroundWorker()
        {
            this.eventTimer = new Timer();
            this.eventTimer.Interval = DataRequestInterval;
            this.eventTimer.Tick += StartWorker;
            this.eventTimer.Start();
        }

        private BindingList<SignInData> GetSignInData()
        {
            IRequestHandler<BindingList<SignInData>, DataRequestPayload> requestHandler = new DataRequest(this.messageHandler);
            DataRequestPayload payload = new DataRequestPayload(this.activeCookie, this.activeCampus);
            return requestHandler.MakeRequest(LogDataURL, payload);
        }

        private void StartWorker(Object obj, EventArgs e)
        {
            this.eventTimer.Stop();
            getSessionDataWorker.RunWorkerAsync();
        }

        private void getSessionDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void getSignInDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        
        private void sessionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                SignInData data = (SignInData)senderGrid.CurrentRow.DataBoundItem;
                DataGridViewCellCollection cells = senderGrid.CurrentRow.Cells;
                Session session = CreateSession(data, cells);



            }
        }

        private Session CreateSession(SignInData data, DataGridViewCellCollection cells)
        {
            this.dataReader.Command = new GetLastInsertedRowIDCommand(this.database, "Session");
            Session session = new Session(Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]));

            session.StudentID = data.StudentID;
            session.Timestamp = data.Timestamp;
            session.Notes = cells["Notes"].Value.ToString();
            session.IsWorkshop = Convert.ToBoolean(cells["IsWorkshop"].Value);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Campus", cells["Campus"].Value.ToString());
            session.CampusID = Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Course", cells["Course"].Value.ToString());
            session.CourseID = Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Center", cells["Center"].Value.ToString());
            session.CenterID = Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Tutor", cells["Tutor"].Value.ToString());
            session.TutorID = Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]);

            this.dataReader.Command = new GetReferenceIDCommand(this.database, "Topic", cells["Topic"].Value.ToString());
            session.TopicID = Convert.ToInt32(this.dataReader.ExecuteCommand().First()[0]);

            return session;
        }
    }
}
