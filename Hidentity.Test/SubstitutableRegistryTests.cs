using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Hidentity.Configuration;

namespace Hidentity.Test
{
    [TestClass]
    public class SubstitutableRegistryTests
    {
        [TestMethod]
        public void if_substitutable_is_added_to_registry_it_can_be_received_by_type_guid()
        {
            //arrange
            Substitutable item = new Substitutable(){TypeName="UserClass", TypeGuid="111", PropertyName="Id"};
            SubstitutablesRegistry.Instance.Add(item);

            //act
            var registryItem = SubstitutablesRegistry.Instance.Find("111").First();

            //assert
            Assert.IsNotNull(registryItem);

            Assert.AreEqual("UserClass", registryItem.TypeName, "TypeName doesn`t match.");
            Assert.AreEqual("111", registryItem.TypeGuid, "TypeGuid doesn`t match.");
            Assert.AreEqual("Id", registryItem.PropertyName, "PropertyName doesn`t match.");
        }

        [TestMethod]
        public void all_added_substitutables_are_loaded_by_type_guid()
        {
            //arrange
            Substitutable item1 = new Substitutable() { TypeName = "UserClass", TypeGuid = "111", PropertyName = "Id" };
            Substitutable item2 = new Substitutable() { TypeName = "UserClass", TypeGuid = "111", PropertyName = "Name" };
            SubstitutablesRegistry.Instance.Add(item1);
            SubstitutablesRegistry.Instance.Add(item2);

            //act
            var res = SubstitutablesRegistry.Instance.Find("111");

            //assert
            Assert.IsInstanceOfType(res, typeof(List<Substitutable>), "Should return list of substitutables");
            Assert.AreEqual("Id", res[0].PropertyName, "First property name is Id.");
            Assert.AreEqual("Name", res[1].PropertyName, "Second property name is Name.");
        }

        [TestMethod]
        public void find_return_null_if_no_elements_for_the_key()
        {
            //arrange
            Substitutable item = new Substitutable() { TypeName = "UserClass", TypeGuid = "111", PropertyName = "Id" };
            SubstitutablesRegistry.Instance.Add(item);

            //act
            var res = SubstitutablesRegistry.Instance.Find("222");

            //assert
            Assert.IsNull(res, "Should be null for 222");
        }

        [TestMethod]
        public void find_return_one_element_array_after_first_add()
        {
            //arrange
            Substitutable item = new Substitutable() { TypeName = "UserClass", TypeGuid = "111", PropertyName = "Id" };
            SubstitutablesRegistry.Instance.Add(item);

            //act
            var res = SubstitutablesRegistry.Instance.Find("111");

            //assert
            Assert.AreEqual(1, res.Count, "Should be only 1 item");
        }

    }
}
