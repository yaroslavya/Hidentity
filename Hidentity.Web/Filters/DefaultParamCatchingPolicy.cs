using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hidentity.Web.Models;
using System.Collections.Generic;
using Hidentity.Configuration;

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

        public Type GetHandlingType(KeyValuePair<string, object> paramObj, string controller, string action) 
        {

            //Some smarter implementtion here. Currently we only work with UserModel and do not use configurartion at all.
            //var hidentities = configuration.GetHidentitiesList()
            //if(hidentities.Contain(controller))
            // return hidentities.GetByName(controller)

            return typeof(UserModel);
        }

        private string GetTypeFromController(string controller) 
        {            
            string typeName = controller;
            if (controller.ToLower().EndsWith("Controller"))
            {
                typeName = controller.Replace("Controller", "");
            }
            //Configurator.HandlingTypeFor(typeName);
            //Configuration.Configurator. we need an interface to check if type is configured by name.
            //if typeName found among list of handling types - use it.
            return typeName;
        }

    }
}
