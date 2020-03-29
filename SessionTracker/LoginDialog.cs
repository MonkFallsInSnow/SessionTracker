using SessionTracker.Modules.Commands;
using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using SessionTracker.Modules.Requests;
using System;
using System.Collections.Specialized;
using System.ComponentModel;

using System.Windows.Forms;


namespace SessionTracker
{
    public partial class LoginDialog : Form, IDataBaseInteraction
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

            IDatabaseCommand command = new GetCampusesCommand(this.database);
            BindingList<Campus> campuses = this.RunDatabaseCommand(command) as BindingList<Campus>;

            BindingSource source = new BindingSource(campuses, null);
            campusComboBox.DataSource = source;
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

        public object RunDatabaseCommand(IDatabaseCommand command)
        {
            Invoker<object> invoker = new Invoker<object>
            {
                Command = command
            };
            return invoker.ExecuteCommand();
        }
    }
}