using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

using Hidentity;

namespace Hidentity.Web
{
    public interface IParamCatchingPolicy
    {
        //TODO: refactor below 2 methods, substitute cascade of params with 1 parameter object.
        bool IsSubstitutable(KeyValuePair<string, object> paramObj, string controllerName, string actionName);
        Type GetHandlingType(KeyValuePair<string, object> paramObj, string controllerName, string actonName);        
    }
}
