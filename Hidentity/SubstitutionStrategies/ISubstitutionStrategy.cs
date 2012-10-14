using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hidentity
{
    /// <summary>
    /// Performs different types of substitution to convert ids between hidden and real. 
    /// Assumes that provided hidden was received as a product of applying ToHidden of the same strategy. 
    /// </summary>
    public interface ISubstitutionStrategy
    {
        /// <summary>
        /// Converts provided integer value to real id from hidden id.
        /// </summary>
        /// <param name="hiddenValue"></param>
        /// <returns></returns>
        int ToReal(int hiddenValue);

        /// <summary>
        /// Converts provided integer value to hidden id from real id.
        /// </summary>
        /// <param name="realValue"></param>
        /// <returns></returns>
        int ToHidden(int realValue);
    }
}
