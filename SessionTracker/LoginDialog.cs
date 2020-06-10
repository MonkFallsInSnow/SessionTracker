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
using System.Web;
using System.Windows.Forms;


namespace SessionTracker
{
    public partial class LoginDialog : Form
    {
        private static readonly string LoginToken = "Login";
        private static readonly string LoginURL = @"https://ilctimetrk.waketech.edu/login";

        private NameValueCollection loginData;
        private IRequestHandler<string, NameValueCollection> requestHandler;
        private IDatabase database;
        private IMessageHandler messageHandler;

        public string ActiveCookie { get; private set; }
        public IDNamePair ActiveCampus { get; private set; }

        public LoginDialog(IRequestHandler<string, NameValueCollection> requestHandler, IDatabase database, IMessageHandler messageHandler)
        {
            InitializeComponent();

            this.requestHandler = requestHandler;
            this.database = database;
            this.messageHandler = messageHandler;

            loginData = HttpUtility.ParseQueryString(string.Empty);

            BindingSource source = new BindingSource(this.GetCampuses(), null);
            campusComboBox.DataSource = source;
        }

        private BindingList<IDNamePair> GetCampuses()
        {
            BindingList<IDNamePair> campuses = new BindingList<IDNamePair>();

            try
            {
                foreach (var item in this.database.Read(DbCommandResource.SelectCampuses))
                {
                    campuses.Add(new IDNamePair(item["ID"], item["Name"]));
                }

                return campuses;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            
            loginData.Add("username", usernameTextbox.Text);
            loginData.Add("password", passwordTextbox.Text);
            loginData.Add("submit", LoginToken);

            string response = this.requestHandler.MakeRequest(LoginURL, loginData);

            if (!string.IsNullOrEmpty(response))
            {
                this.DialogResult = DialogResult.OK;
                this.ActiveCookie = response;
                this.ActiveCampus = ((IDNamePair)campusComboBox.Items[campusComboBox.SelectedIndex]);
            } 
        }

        
    }
}