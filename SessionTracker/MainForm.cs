﻿using SessionTracker.Modules.Data;
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

        public SessionTrackerMainForm(IDatabase database, IMessageHandler messageHandler, string cookie, Campus campus)
        {
            InitializeComponent();

            this.activeCookie = cookie;
            this.activeCampus = campus;
            this.database = database;
            this.messageHandler = messageHandler;
            this.dataReader = new DatabaseReader();

            this.Text = $"Session Tracker - {this.activeCampus.Name}";
            
            this.InitializeDataGridView();
            this.StartBackgroundWorker();
        }

        private void InitializeDataGridView()
        {
            BindingList<SignInData> dataSource = this.GetSignInData();
            BindingSource source = new BindingSource(dataSource, null);

            sessionDataGridView.AutoGenerateColumns = true;
            sessionDataGridView.DataSource = source;
            
            //BindingList<Tutor> tutors = (BindingList<Tutor>)dataHandler.GetTutors(this.SessionCampus.ID);

            //source = new BindingSource(signInData, null);
            //logGrid.DataSource = source;

            //source = new BindingSource(tutors, null);
            //tutorComboBox.DataSource = source;
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
    }
}
