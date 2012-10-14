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
        bool IsSubstitutable(KeyValuePair<string, object> paramObj, string controllerName, string actionName);
        ISubstitutionStrategy GetSubstitutionStrategyFor();
    }
}
