using SessionTracker.Modules.Commands;
using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using SessionTracker.Modules.Requests;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

using System.Windows.Forms;


namespace SessionTracker
{
    public partial class LoginDialog : Form
    {
        private NameValueCollection loginData;
        private IRequestHandler<string, NameValueCollection> requestHandler;
        private IDatabase database;
        private IMessageHandler messageHandler;

        public string SessionCookie { get; private set; }
        public object HttpUtility { get; }

        //public Campus SessionCampus { get; private set; }

        public LoginDialog(IRequestHandler<string, NameValueCollection> requestHandler, IDatabase database, IMessageHandler messageHandler)
        {
            InitializeComponent();

            this.requestHandler = requestHandler;
            this.database = database;
            this.messageHandler = messageHandler;

            //loginData = HttpUtility.ParseQueryString(String.Empty);

            BindingSource source = new BindingSource(this.GetCampuses(), null);
            campusComboBox.DataSource = source;
        }

        private BindingList<Campus> GetCampuses()
        {
            BindingList<Campus> campuses = new BindingList<Campus>();

            IDatabaseReadCommand command = new GetCampusesCommand(this.database);
            DatabaseReader invoker = new DatabaseReader(command);

            var data = invoker.ExecuteCommand();
            
            foreach (var d in data)
            {
                campuses.Add((Campus)d);
            }

            return campuses;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            /*
            loginData.Add("username", usernameTextbox.Text);
            loginData.Add("password", passwordTextbox.Text);
            loginData.Add("submit", Constants.LoginToken);

            string response = this.requestHandler.MakeRequest(Constants.LoginURL, loginData);

            if (!string.IsNullOrEmpty(response))
            {
                this.DialogResult = DialogResult.OK;
                this.SessionCookie = response;
                this.SessionCampus = ((Campus)campusComboBox.Items[campusComboBox.SelectedIndex]);
            }
            */
        }
    }
}