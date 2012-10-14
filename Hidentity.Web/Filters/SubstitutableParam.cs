using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hidentity.Web
{
    public class SubstitutableParam: ISubstitutableParam
    {
        public string Name {get;set;}
        public object Value {get;set;}
        public Type HandlingType { get; set; }
    }
}
