using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hidentity
{
    /// <summary>
    /// Substitutes id from real one to secured and vice versa.
    /// </summary>
    public class Substitutor : ISubstitutor
    {
        public int ToHiddenId(int realId) 
        {
            //TODO: switch to some other substitution methods.
            return realId * 10;
        }

        public int ToRealId(int hiddenId) 
        {
            return hiddenId / 10;
        }

    }
}
