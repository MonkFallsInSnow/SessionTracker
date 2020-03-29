using SessionTracker.Modules.Commands;

namespace SessionTracker.Modules.Data
{
    interface IDataBaseInteraction
    {
        object RunDatabaseCommand(IDatabaseCommand command);
    }
}
