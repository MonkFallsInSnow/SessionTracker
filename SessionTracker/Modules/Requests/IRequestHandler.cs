using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Requests
{
    public interface IRequestHandler<T, U>
    {
        T MakeRequest(string url, U data);
    }

    public interface IRequestHandler<T>
    {
        T MakeRequest(string url);
    }
}
