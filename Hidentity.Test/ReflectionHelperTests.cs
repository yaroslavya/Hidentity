using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hidentity.Configuration;

namespace Hidentity.Test
{
    [TestClass]
    public class ReflectionHelperTests
    {
        [TestMethod]
        public void property_value_received_by_substitutable()
        {
            //arrange
            UserModel model = new UserModel() { Id = 111, Name = "John" };
            Configurator.Substitute<UserModel, int>(x => x.Id);

            Substitutable subs = Configurator.SubstitutesFor(typeof(UserModel)).First();

            //act
            int res = ReflectionHelper.GetValue<UserModel>(model, subs);

            //assert
            Assert.AreEqual(111, res);
            //Assert.AreNotEqual(1, model.Id);
        }

        [TestMethod]
        public void property_set_to_value_provided()
        {
            //arrange
            UserModel model = new UserModel() { Id = 111, Name = "John" };
            Configurator.Substitute<UserModel, int>(x => x.Id);

            Substitutable subs = Configurator.SubstitutesFor(typeof(UserModel)).First();

            //act
            ReflectionHelper.SetValue<UserModel>(model, subs, 10);

            //assert
            Assert.AreEqual(10, model.Id);
        }
    }
}
