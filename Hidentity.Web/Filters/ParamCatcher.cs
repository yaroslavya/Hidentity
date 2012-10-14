using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hidentity.Web.Filters
{
    /// <summary>
    /// Retrieves all the data that goes to the server from the client. 
    /// </summary>
    public class InputDataCatcher
    {
        private InputParamData _inputParams;

        public InputDataCatcher(InputParamData inputParameters)
        {
            _inputParams = inputParameters;
        }

        public IParamCatchingPolicy ParamCatchingPolicy
        {
            get
            {
                return new DefaultParamCatchingPolicy();
            }
            set
            {
            }
        }

        public List<ISubstitutableParam> GetSubstitutableParams()
        {
            //TODO: iterate through every param and get the ones that match substitution policy for current controller/action method.
            //this part was not created yet. We need to configure the way input parameters should be substituted, 
            //same as we configure it for types. There should be a default substitution policy to catch params of the right type.

            //TODO: should return a list of params that we need to substitute according to some substitution strategy.
            //We will iterate via every param and substitute it`s value with the new one. Note, that the policy itself will let us know
            //if we need to substitute a simple type param or a complex type value.
            List<ISubstitutableParam> paramList = new List<ISubstitutableParam>();
            ISubstitutableParam par = new SubstitutableParam() { HandlingType = ParamCatchingPolicy.GetType(), Name = "id", Value = _inputParams.GetValueByName("id") };
            paramList.Add(par);

            return paramList;
        }
    }
}