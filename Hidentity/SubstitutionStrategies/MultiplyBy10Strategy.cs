using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hidentity
{
    public class MultiplyBy10Strategy:ISubstitutionStrategy
    {
        public int ToReal(int hiddenValue)
        {
            return hiddenValue / 10;
        }

        public int ToHidden(int realValue)
        {
            return realValue * 10;
        }
    }
}
