using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hidentity.Web
{
    public class DefaultParamCatchingPolicy:IParamCatchingPolicy
    {
        public bool IsSubstitutable(System.Collections.Generic.KeyValuePair<string, object> paramObj, string controllerName, string actionName)
        {
            //TODO: as a default param catching policy we should check if there are a special 
            //handling for current input param defined in configuration. If there are - handle it correspondingly.
            if (paramObj.Key.ToLower().Contains("id"))
                return true;

            return false;
        }

        public ISubstitutionStrategy GetSubstitutionStrategyFor() 
        {
            //TODO: We should check configuration for available strategies. If there`s only one - use it. 
            //if there`s more - make choice depending on configuration.
            return new MultiplyBy10Strategy();
        }
    }
}
