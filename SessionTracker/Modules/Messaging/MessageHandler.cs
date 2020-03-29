using System.Windows.Forms;

namespace SessionTracker.Modules.Messaging
{
    class MessageHandler : IMessageHandler
    {
        public void ShowDialog(string title, string message, MessageBoxIcon type)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                type
            );
        }
    }
}
