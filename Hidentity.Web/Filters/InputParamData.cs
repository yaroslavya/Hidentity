using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace Hidentity.Web
{
    /// <summary>
    /// Special data parameter class to store everything we need from request to get parameters to substitute.
    /// </summary>
    public class InputParamData
    {
        public IDictionary<string, object> InputParams { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public object GetValueByName(string name) 
        {
            return InputParams[name];
        }
    }
}
