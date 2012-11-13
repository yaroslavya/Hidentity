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
        private ISubstitutionStrategy _strategy;

        public Substitutor(ISubstitutionStrategy strategy) 
        {
            _strategy = strategy;
        }

        public int ToHiddenId(int realId) 
        {
            //TODO: switch to some other substitution methods.
            return _strategy.ToHidden(realId);
            //return realId * 10;
        }

        public int ToRealId(int hiddenId) 
        {
            return _strategy.ToReal(hiddenId);
        }

    }
}
