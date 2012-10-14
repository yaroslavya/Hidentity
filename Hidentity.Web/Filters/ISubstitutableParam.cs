using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hidentity.Web
{
    public interface ISubstitutableParam
    {
        string Name { get; set; }
        object Value { get; set; }
        Type HandlingType { get; set; }
    }
}
