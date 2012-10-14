using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hidentity.Configuration
{
    /// <summary>
    /// This class stores all the information we need to perform substitution.
    /// </summary>
    public class Substitutable
    {
        public string TypeName { get; set; }
        public string PropertyName { get; set; }
        public string TypeGuid { get; set; }
    }
}
