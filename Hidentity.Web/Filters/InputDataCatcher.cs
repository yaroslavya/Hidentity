using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hidentity.Configuration;

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
            string controllerName = _inputParams.ControllerName;
            string actionName = _inputParams.ActionName;
            List<ISubstitutableParam> paramList = new List<ISubstitutableParam>();

            foreach (var item in _inputParams.InputParams) 
            {
                if (ParamCatchingPolicy.IsSubstitutable(item, controllerName, actionName))
                { 
                    //TODO: currently we are setting policy with which param was caught. It seems we have to add a substitutable strategy class for the type
                    //or for related type. E.g. if we are substituting int id we have to find the related substitutable type by controller and action name
                    //like for User/Add will be UserModel and we should use UserModel substitution strategy. Later we will iterate through all the caught
                    //params and substitute them using the strategy attached.
                    var handlingType = ParamCatchingPolicy.GetHandlingType(item, controllerName, actionName);
                    ISubstitutableParam par = new SubstitutableParam() { HandlingType = handlingType, Name = item.Key, Value = item.Value};

                    paramList.Add(par);
                }
            }

            return paramList;
        }
        
    }
}