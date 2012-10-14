using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hidentity.Configuration;

namespace Hidentity.Test
{
    [TestClass]
    public class when_entity_subtitutor_change_hidden_to_real
    {
        [TestMethod]
        public void null_object_remains_null_after_substitution()
        {
            //arrange
            UserModel model = null;
            var subsItem = Configurator.SubstitutesFor(typeof(UserModel));

            //act
            EntitySubstitutor.EntityToReal<UserModel>(model);

            //assert
            Assert.AreEqual(null, model, "Should remain null");
        }

        [TestMethod]
        public void property_remains_the_same_if_no_substitution_was_added()
        {
            //arrange
            UserModel model = new UserModel() { Id = 100, Name = "John" };
            var subsItem = Configurator.SubstitutesFor(model.GetType());

            //act
            EntitySubstitutor.EntityToReal<UserModel>(model);

            //assert
            Assert.AreEqual(100, model.Id, "Id should be the same as we didn`t configure the substitutable.");
        }

        [TestMethod]
        public void single_id_property_is_substituted()
        {
            //arrange
            Configurator.Substitute<UserModel, int>(x => x.Id);

            UserModel model = new UserModel(){Id=100, Name="John"};
            var subsItem = Configurator.SubstitutesFor(model.GetType());

            //act
            EntitySubstitutor.EntityToReal<UserModel>(model);

            //assert
            Assert.AreEqual(10, model.Id, "Id should be substituted to real");
        }
    }
}
