using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hidentity.Web.Filters
{
    //TODO: make it a filter that will intercept input parameters and substitute them on executing. and on executed it should 
    //substitute id back in all the entities.
    public class HidentityFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //TODO: get all the input parameters data and substitute it to real ids from synthetic ones.
            //Note that handling complex types as input parameters also needed, but for that filter should be configured
            //correspondingly. So that if you need to substitute customer.Id you should make something 
            //like substitute.ForType<CustomerType>().Name(x=>x.Id);
            //How to perform correct substitution for input parameters? For now we can substitute all the parameters that are named id
            //and contain entity name + id into their name. also we should check if they are int convertible or not.
        }

        private void GetSubstitutableParams(ActionExecutingContext filterContext) 
        {
            List<int> paramList = new List<int>();
        }
    }
}