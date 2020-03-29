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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMessageHandler messageHandler = new MessageHandler();

            using (IDatabase database = new Database("database.sqlite", messageHandler))
            using (database.Connection)
            {
                database.Connection.Open();

                IRequestHandler<string, NameValueCollection> loginRequestHandler = new LoginRequest(messageHandler);
                IRequestHandler<BindingList<SignInData>, DataRequestPayload> dataRequestHandler = new DataRequest(messageHandler);

                LoginDialog loginDialog = new LoginDialog(loginRequestHandler, database, messageHandler);

                DialogResult result = loginDialog.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.OK)
                {
                    loginDialog.Close();
                    SessionTrackerMainForm mainForm = new SessionTrackerMainForm();
                    Application.Run(mainForm);

                }
                else
                {
                    loginDialog.Refresh();
                }
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
