using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hidentity.Configuration;

namespace Hidentity.Test
{
    [TestClass]
    public class ConfiguratorTests
    {        
        [TestMethod]
        public void property_name_evaluated_correctly()
        {
            string name = Configurator.MemberName<UserModel, int>(x => x.Id);
            Assert.AreEqual(name, "Id", "Should be Id");
        }

        [TestMethod]
        public void if_property_added_configurator_shows_substitutables_for_the_type()
        {
            Configurator.Substitute<UserModel, int>(x => x.Id);
            var substitutes = Configurator.SubstitutesFor(typeof(UserModel));

            Assert.AreEqual(1, substitutes.Count, "Should contain 1 element.");
            Assert.AreEqual("Id", substitutes[0].PropertyName, "Should be Id property.");
            Assert.AreEqual("UserModel", substitutes[0].TypeName, "Should be UserModel class.");
        }
       
    }
}
