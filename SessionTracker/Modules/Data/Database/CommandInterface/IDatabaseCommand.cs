using System.Collections.Generic;
using System.Collections.Specialized;

namespace SessionTracker.Modules.Data.Database
{
    public interface IDatabaseCommand<T>
    {
        T Execute();
    }

    public interface IDatabaseReadCommand : IDatabaseCommand<IEnumerable<NameValueCollection>>
    {
    }

    public interface IDatabaseWriteCommand : IDatabaseCommand<int>
    {
    }
}
