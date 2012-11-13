using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hidentity.Configuration;

namespace Hidentity
{
    public class DefaultCatchingPolicy:ISubstitutableCatchingPolicy
    {
        public bool IsSubstitutable(KeyValuePair<string, object> paramObj, string controllerName, string actionName)
        {
            
            throw new NotImplementedException();
        }

        public Type GetHandlingType(KeyValuePair<string, object> paramObj, string controllerName, string actonName)
        {
            return typeof(object);//Configurator.HandlingTypeFor((ISubstitutableCatchingPolicy) this).HandlingType;
        }
    }
}
