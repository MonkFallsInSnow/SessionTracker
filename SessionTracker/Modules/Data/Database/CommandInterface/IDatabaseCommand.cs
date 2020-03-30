using System.Collections.Generic;

namespace SessionTracker.Modules.Data.Database
{
    public interface IDatabaseCommand<T>
    {
        T Execute();
    }

    public interface IDatabaseReadCommand : IDatabaseCommand<IList<object>>
    {
    }

    public interface IDatabaseWriteCommand : IDatabaseCommand<int>
    {
    }
}
