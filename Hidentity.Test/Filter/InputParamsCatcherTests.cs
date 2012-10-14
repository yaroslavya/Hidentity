using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hidentity.Web;
using Hidentity.Web.Filters;

namespace Hidentity.Test.Filter
{
    [TestClass]
    public class InputParamsCatcherTests
    {
        [TestMethod]
        public void id_input_param_should_be_handled_by_default()
        {
            //arrange
            IDictionary<string, object> items = new Dictionary<string, object>();
            items.Add("id", 10);

            InputParamData data = new InputParamData(){ActionName="Add", ControllerName="User", InputParams= items};
            InputDataCatcher catcher = new InputDataCatcher(data);

            //act
            var subsParams = catcher.GetSubstitutableParams();
            var param = subsParams[0];

            //assert
            Assert.IsNotNull(subsParams, "Should not be null");
            Assert.AreEqual("id", param.Name, "Should be User controller");
            Assert.AreEqual(10, param.Value, "Should be 10");
        }

        [TestMethod]
        public void substitution_policy_should_be_default_if_we_didnt_set_any()
        {
            //arrange
            IDictionary<string, object> items = new Dictionary<string, object>();
            items.Add("id", 10);

            InputParamData data = new InputParamData() { ActionName = "Add", ControllerName = "User", InputParams = items };
            InputDataCatcher catcher = new InputDataCatcher(data);

            //act
            var subsParams = catcher.GetSubstitutableParams();
            var param = subsParams[0];

            //assert
            Assert.AreEqual("DefaultSubstitutionPolicy", param.HandlingType, "Should be default policy");
        }
    }
}
