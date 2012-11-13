using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hidentity
{
    public interface ISubstitutableCatchingPolicy
    {
        bool IsSubstitutable(KeyValuePair<string, object> paramObj, string controllerName, string actionName);
        Type GetHandlingType(KeyValuePair<string, object> paramObj, string controllerName, string actonName);
    }
}
