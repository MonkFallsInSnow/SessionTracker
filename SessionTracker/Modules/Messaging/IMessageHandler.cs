using System.Windows.Forms;

namespace SessionTracker.Modules.Messaging
{
    public interface IMessageHandler
    {
        void ShowDialog(string title, string message, MessageBoxIcon type);
    }
}
